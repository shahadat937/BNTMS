using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Handlers.Commands
{
    public class AcceptedCourseBudgetAllocationCommandHandler : IRequestHandler<AcceptedCourseBudgetAllocationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AcceptedCourseBudgetAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(AcceptedCourseBudgetAllocationCommand request, CancellationToken cancellationToken)
        {
            var CourseBudgetAllocation = await _unitOfWork.Repository<CourseBudgetAllocation>().Get(request.CourseBudgetAllocationId);
            CourseBudgetAllocation.ReceivedStatus = 1;

            if (CourseBudgetAllocation == null)
                throw new NotFoundException(nameof(CourseBudgetAllocation), request.CourseBudgetAllocationId);

            await _unitOfWork.Repository<CourseBudgetAllocation>().Update(CourseBudgetAllocation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
