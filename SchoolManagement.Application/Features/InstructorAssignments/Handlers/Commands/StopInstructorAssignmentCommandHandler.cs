using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.InstructorAssignments.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.InstructorAssignments.Handlers.Commands
{
    public class StopInstructorAssignmentCommandHandler : IRequestHandler<StopInstructorAssignmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StopInstructorAssignmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(StopInstructorAssignmentCommand request, CancellationToken cancellationToken)
        {
            var InstructorAssignment = await _unitOfWork.Repository<InstructorAssignment>().Get(request.InstructorAssignmentId);
            InstructorAssignment.Status = 1;

            if (InstructorAssignment == null)
                throw new NotFoundException(nameof(InstructorAssignment), request.InstructorAssignmentId);

            await _unitOfWork.Repository<InstructorAssignment>().Update(InstructorAssignment);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
