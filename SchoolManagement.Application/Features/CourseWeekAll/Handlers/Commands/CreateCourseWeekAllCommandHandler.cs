using SchoolManagement.Application.Features.CourseWeekAll.Requests.Commands;
using SchoolManagement.Application.Responses;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseWeeks.Validators;
using SchoolManagement.Application.DTOs.CourseWeekAll.Validators;
using SchoolManagement.Application.DTOs.CourseWeekAll;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseWeekAll.Handlers.Commands
{
    public class CreateCourseWeekAllCommandHandler : IRequestHandler<CreateCourseWeekAllCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseWeekAllCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseWeekAllCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseWeekAllDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseWeekAllDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CourseWeekAll = _mapper.Map<SchoolManagement.Domain.CourseWeekAll>(request.CourseWeekAllDto);

               CourseWeekAll = await _unitOfWork.Repository<SchoolManagement.Domain.CourseWeekAll>().Add(CourseWeekAll);

                //CourseWeek.DateFrom = CourseWeek.DateFrom.Value.AddDays(1.0);
                //CourseWeek.DateTo = CourseWeek.DateTo.Value.AddDays(1.0);

                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CourseWeekAll.WeekID;
            }

            return response;
        }
    }
}
