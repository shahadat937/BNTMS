using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InstructorAssignments.Validators;
using SchoolManagement.Application.Features.InstructorAssignments.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.InstructorAssignments.Handlers.Commands
{
    public class CreateInstructorAssignmentCommandHandler : IRequestHandler<CreateInstructorAssignmentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateInstructorAssignmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateInstructorAssignmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateInstructorAssignmentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.InstructorAssignmentDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var InstructorAssignment = _mapper.Map<InstructorAssignment>(request.InstructorAssignmentDto);
                InstructorAssignment.Status = 0;

                InstructorAssignment = await _unitOfWork.Repository<InstructorAssignment>().Add(InstructorAssignment);
                InstructorAssignment.StartDate = InstructorAssignment.StartDate.Value.AddDays(1.0);
                InstructorAssignment.EndDate = InstructorAssignment.EndDate.Value.AddDays(1.0);
                await _unitOfWork.Save();
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = InstructorAssignment.InstructorAssignmentId;
            }

            return response;
        }
    }
}
