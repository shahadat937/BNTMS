using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CoursePlans.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Commands
{
    public class CreateCoursePlanCommandHandler : IRequestHandler<CreateCoursePlanCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCoursePlanCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCoursePlanCommand request, CancellationToken cancellationToken)
        {
            //var response = new BaseCommandResponse();
            //var validator = new CreateCoursePlanDtoValidator();
            //var validationResult = await validator.ValidateAsync(request.CoursePlanDto);

            //if (validationResult.IsValid == false)
            //{
            //    response.Success = false;
            //    response.Message = "Creation Failed";
            //    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            //}
            //else
            //{
            //    var CoursePlan = _mapper.Map<CoursePlanCreate>(request.CoursePlanDto);

            //    CoursePlan = await _unitOfWork.Repository<CoursePlanCreate>().Add(CoursePlan);

            //    try
            //    {
            //        await _unitOfWork.Save();
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Console.WriteLine(ex);
            //    }


            //    response.Success = true;
            //    response.Message = "Creation Successful";
            //    response.Id = CoursePlan.CoursePlanCreateId;
            //}

            //return response;

            var response = new BaseCommandResponse();

            var attendance = request.CoursePlanDto;

            var attendanceList = attendance.CoursePlanList.Select(x => new CoursePlanCreate()
            {
                CourseDurationId = attendance.CourseDurationId,
                CourseNameId = attendance.CourseNameId,
                BaseSchoolNameId = attendance.BaseSchoolNameId,
                CoursePlanName = x.CoursePlanName,
                Value = x.Value,
                Status = attendance.Status,
                MenuPosition = attendance.MenuPosition,
                IsActive = attendance.IsActive
            });
            await _unitOfWork.Repository<CoursePlanCreate>().AddRangeAsync(attendanceList);

            await _unitOfWork.Save();

            //try
            //{
            //    foreach (var item in attendanceList)
            //    {
            //        await _unitOfWork.Repository<Attendance>().Update(item);
            //        await _unitOfWork.Save();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //await _unitOfWork.Repository<Attendance>().AddRangeAsync(attendanceList);

            // await _unitOfWork.Save();

            //var attendances = _mapper.Map<List<Attendance>>(request.ApprovedAttendanceDto);

            //foreach (var item in attendances)
            //{
            //if (item.AttendanceStatus == null)
            //{
            //    item.AttendanceStatus = false;

            //await _unitOfWork.Repository<Attendance>().Update(item);
            //await _unitOfWork.Save();
            //}

            //else
            //{
            //    await _unitOfWork.Repository<Attendance>().Add(item);
            //    await _unitOfWork.Save();
            //}
            //}

            //var routines = await _unitOfWork.Repository<ClassRoutine>().Get(request.AttendanceListDto.Select(x => x.ClassRoutineId.Value).FirstOrDefault());

            //routines.AttendanceComplete = CompleteStatus.Completed;

            //await _unitOfWork.Repository<ClassRoutine>().Update(routines);
            //await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
