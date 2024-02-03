using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseWeeks.Validators;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Commands
{
    public class CreateCourseWeekCommandHandler : IRequestHandler<CreateCourseWeekCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseWeekCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseWeekCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseWeekDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseWeekDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CourseWeek = _mapper.Map<CourseWeek>(request.CourseWeekDto);

                CourseWeek = await _unitOfWork.Repository<CourseWeek>().Add(CourseWeek);

                CourseWeek.DateFrom = CourseWeek.DateFrom.Value.AddDays(1.0);
                CourseWeek.DateTo = CourseWeek.DateTo.Value.AddDays(1.0);

                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CourseWeek.CourseWeekId;
            }

            return response;
        }
    }
}
