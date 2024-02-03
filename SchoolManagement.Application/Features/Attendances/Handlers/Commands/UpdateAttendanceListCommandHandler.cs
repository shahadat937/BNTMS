using AutoMapper;
using SchoolManagement.Application.Features.Attendances.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Constants;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Commands
{
    public class UpdateAttendanceListCommandHandler : IRequestHandler<UpdateAttendanceListCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAttendanceListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateAttendanceListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var attendance = request.ApprovedAttendanceDto;

            var attendanceList = attendance.TraineeListForm.Select(x => new Attendance()
            {
                AttendanceId = x.AttendanceId.Value,
                BnaSubjectNameId = x.BnaSubjectNameId,
                AttendanceDate = x.AttendanceDate,
                AttendanceStatus =x.AttendanceStatus,
                Status = attendance.Status,
                BaseSchoolNameId = x.BaseSchoolNameId,
                BnaAttendanceRemarksId = x.BnaAttendanceRemarksId,
                CourseDurationId = x.CourseDurationId,
                ClassRoutineId = x.ClassRoutineId,
                CourseNameId = x.CourseNameId,
                ClassPeriodId = x.ClassPeriodId,
                TraineeId = x.TraineeId,
                ClassLeaderName = x.ClassLeaderName,
                DateCreated = x.DateCreated,
                CreatedBy =x.CreatedBy
            });
            try
            {
                foreach (var item in attendanceList)
                {
                    await _unitOfWork.Repository<Attendance>().Update(item);
                    await _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
