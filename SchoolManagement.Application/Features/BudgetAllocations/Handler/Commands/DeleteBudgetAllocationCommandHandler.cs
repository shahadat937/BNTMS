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
    public class DeleteBudgetAllocationCommandHandler : IRequestHandler<DeleteBudgetAllocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBudgetAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBudgetAllocationCommand request, CancellationToken cancellationToken)
        {
            var BudgetAllocation = await _unitOfWork.Repository<BudgetAllocation>().Get(request.BudgetAllocationId);

            if (BudgetAllocation == null)
                throw new NotFoundException(nameof(BudgetAllocation), request.BudgetAllocationId);

            await _unitOfWork.Repository<BudgetAllocation>().Delete(BudgetAllocation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}