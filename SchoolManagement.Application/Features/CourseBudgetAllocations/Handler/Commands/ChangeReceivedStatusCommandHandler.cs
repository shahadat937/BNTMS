using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Handlers.Commands
{
    public class ChangeReceivedStatusCommandHandler : IRequestHandler<ChangeReceivedStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public ChangeReceivedStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ChangeReceivedStatusCommand request, CancellationToken cancellationToken)
        {
            var CourseBudgetAllocation = await _unitOfWork.Repository<CourseBudgetAllocation>().Get(request.CourseBudgetAllocationId);
            CourseBudgetAllocation.ReceivedStatus = request.ReceivedStatus;

            
            await _unitOfWork.Repository<CourseBudgetAllocation>().Update(CourseBudgetAllocation);
            await _unitOfWork.Save();

            

            return Unit.Value;
        }
    }
}
