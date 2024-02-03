using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseInstructors.Validators;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Commands
{
    public class CreateCourseInstructorCommandHandler : IRequestHandler<CreateCourseInstructorCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseInstructorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseInstructorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseInstructorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseInstructorDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
            
                var CourseInstructor = _mapper.Map<CourseInstructor>(request.CourseInstructorDto);

                CourseInstructor = await _unitOfWork.Repository<CourseInstructor>().Add(CourseInstructor);
              //  CourseInstructor.MarkEntryStatus = 0;
             
                await _unitOfWork.Save();
            
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CourseInstructor.CourseInstructorId;
            }

            return response;
        }
    }
}
