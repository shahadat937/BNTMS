using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Handler.Commands
{
    public class DeleteCourseBudgetAllocationCommandHandler : IRequestHandler<DeleteCourseBudgetAllocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseBudgetAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseBudgetAllocationCommand request, CancellationToken cancellationToken)
        {
            var CourseBudgetAllocation = await _unitOfWork.Repository<CourseBudgetAllocation>().Get(request.CourseBudgetAllocationId);

            if (CourseBudgetAllocation == null)
                throw new NotFoundException(nameof(CourseBudgetAllocation), request.CourseBudgetAllocationId);

            await _unitOfWork.Repository<CourseBudgetAllocation>().Delete(CourseBudgetAllocation);
            await _unitOfWork.Save();

            if (CourseBudgetAllocation.PaymentTypeId == 2)
            {
                var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(CourseBudgetAllocation.BudgetCodeId.Value);
                budgetCode.TargetAmount -= CourseBudgetAllocation.InstallmentAmount;

                await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
                await _unitOfWork.Save();
            }

            else if (CourseBudgetAllocation.PaymentTypeId == 1)
            {
                var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(CourseBudgetAllocation.BudgetCodeId.Value);
                budgetCode.AvailableAmount += CourseBudgetAllocation.InstallmentAmount;

                if (budgetCode.AvailableAmount >= 0)
                {
                    await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
                    await _unitOfWork.Save();
                }
            }

            return Unit.Value;
        }
    }
}