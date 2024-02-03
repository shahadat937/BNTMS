using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.InstructorAssignments.Requests.Commands;
using SchoolManagement.Application.DTOs.InstructorAssignments.Validators;

namespace SchoolManagement.Application.Features.InstructorAssignments.Handlers.Commands
{
    public class UpdateInstructorAssignmentCommandHandler : IRequestHandler<UpdateInstructorAssignmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateInstructorAssignmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateInstructorAssignmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInstructorAssignmentDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.InstructorAssignmentDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var InstructorAssignment = await _unitOfWork.Repository<InstructorAssignment>().Get(request.InstructorAssignmentDto.InstructorAssignmentId);

            if (InstructorAssignment is null)
                throw new NotFoundException(nameof(InstructorAssignment), request.InstructorAssignmentDto.InstructorAssignmentId);

            _mapper.Map(request.InstructorAssignmentDto, InstructorAssignment);

            await _unitOfWork.Repository<InstructorAssignment>().Update(InstructorAssignment);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
