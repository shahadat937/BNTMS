using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs.CourseInstructors.Validators;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Commands;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Commands
{
    public class UpdateCourseInstructorCommandHandler : IRequestHandler<UpdateCourseInstructorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseInstructorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseInstructorCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseInstructorDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CourseInstructorDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseInstructor = await _unitOfWork.Repository<CourseInstructor>().Get(request.CourseInstructorDto.CourseInstructorId);

            if (CourseInstructor is null)
                throw new NotFoundException(nameof(CourseInstructor), request.CourseInstructorDto.CourseInstructorId);
          
            _mapper.Map(request.CourseInstructorDto, CourseInstructor);


            CourseInstructor.CourseName = null;
            await _unitOfWork.Repository<CourseInstructor>().Update(CourseInstructor);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
