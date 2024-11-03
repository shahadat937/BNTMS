using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BudgetAllocations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetAllocations.Handler.Commands
{
    public class DeleteBudgetAllocationCommandHandler : IRequestHandler<Requests.Commands.DeleteBudgetAllocationCommandHandler>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBudgetAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Requests.Commands.DeleteBudgetAllocationCommandHandler request, CancellationToken cancellationToken)
        {
            var BudgetAllocation = await _unitOfWork.Repository<BudgetAllocation>().Get(request.BudgetAllocationId);

           
            if (BudgetAllocation == null)
                throw new NotFoundException(nameof(BudgetAllocation), request.BudgetAllocationId);

            var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(BudgetAllocation.BudgetCodeId);

            if (budgetCode != null)
            {
           
                budgetCode.TotalBudget -= BudgetAllocation.Amount;

              
                if (budgetCode.TotalBudget < 0)
                    throw new InvalidOperationException("Total budget would go negative after deletion.");

                await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
            }

            await _unitOfWork.Repository<BudgetAllocation>().Delete(BudgetAllocation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}