using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Commands;
using SchoolManagement.Application.DTOs.CourseWeeks.Validators;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Commands
{
    public class UpdateCourseWeekCommandHandler : IRequestHandler<UpdateCourseWeekCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseWeekCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseWeekCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseWeekDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CourseWeekDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseWeek = await _unitOfWork.Repository<CourseWeek>().Get(request.CourseWeekDto.CourseWeekId);

            if (CourseWeek is null)
                throw new NotFoundException(nameof(CourseWeek), request.CourseWeekDto.CourseWeekId);

            _mapper.Map(request.CourseWeekDto, CourseWeek);

            await _unitOfWork.Repository<CourseWeek>().Update(CourseWeek);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
