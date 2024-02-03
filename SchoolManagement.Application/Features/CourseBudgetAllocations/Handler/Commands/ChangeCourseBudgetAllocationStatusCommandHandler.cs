using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Handlers.Commands
{
    public class ChangeCourseBudgetAllocationStatusCommandHandler : IRequestHandler<ChangeCourseBudgetAllocationStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public ChangeCourseBudgetAllocationStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ChangeCourseBudgetAllocationStatusCommand request, CancellationToken cancellationToken)
        {
            var CourseBudgetAllocation = await _unitOfWork.Repository<CourseBudgetAllocation>().Get(request.CourseBudgetAllocationId);
            CourseBudgetAllocation.Status = request.Status;

            if (CourseBudgetAllocation == null)
                throw new NotFoundException(nameof(CourseBudgetAllocation), request.CourseBudgetAllocationId);

            CourseBudgetAllocation.PaymentDate = DateTime.Now;

            await _unitOfWork.Repository<CourseBudgetAllocation>().Update(CourseBudgetAllocation);
            await _unitOfWork.Save();

            var budgetCode = await _unitOfWork.Repository<BudgetCode>().Get(CourseBudgetAllocation.BudgetCodeId.Value);
            budgetCode.TargetAmount -= CourseBudgetAllocation.InstallmentAmount;
            budgetCode.AvailableAmount -= CourseBudgetAllocation.InstallmentAmount;


            if(budgetCode.TargetAmount >= 0 && budgetCode.AvailableAmount >= 0)
            {
                await _unitOfWork.Repository<BudgetCode>().Update(budgetCode);
                await _unitOfWork.Save();
            }

            return Unit.Value;
        }
    }
}
