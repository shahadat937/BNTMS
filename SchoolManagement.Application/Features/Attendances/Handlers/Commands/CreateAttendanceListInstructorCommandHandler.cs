using AutoMapper;
using SchoolManagement.Application.Features.Attendances.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Constants;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Commands
{
    public class CreateAttendanceListInstructorCommandHandler : IRequestHandler<CreateAttendanceListInstructorCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAttendanceListInstructorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAttendanceListInstructorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var attendanceList = request.AttendanceListInstructorDto;

            foreach (var item in attendanceList.TraineeListForm)
            {
                if (item.AttendanceStatus == null) 
                {
                    item.AttendanceStatus = false;
                }
            }

            var attendances = attendanceList.TraineeListForm.Select(x => new Attendance()
            {
                AttendanceStatus = x.AttendanceStatus,
                AbsentForExamStatus = !x.AttendanceStatus,
                AttendanceDate = DateTime.Now,
                BaseSchoolNameId = attendanceList.BaseSchoolNameId,
                ClassRoutineId = attendanceList.ClassRoutineId,
                CourseDurationId = attendanceList.CourseDurationId,
                CourseSectionId = attendanceList.CourseSectionId,
                CourseNameId = x.CourseNameId,
                BnaSubjectNameId = attendanceList.BnaSubjectNameId,
                ClassPeriodId = attendanceList.ClassPeriodIds,
                Status = 1,
                TraineeId = x.TraineeId,
                BnaAttendanceRemarksId =x.BnaAttendanceRemarksId
            });

            await _unitOfWork.Repository<Attendance>().AddRangeAsync(attendances);
            await _unitOfWork.Save();

            var routines = await _unitOfWork.Repository<ClassRoutine>().Get(request.AttendanceListInstructorDto.ClassRoutineId.Value);
            
            routines.AttendanceComplete = CompleteStatus.Completed; 

            await _unitOfWork.Repository<ClassRoutine>().Update(routines); 
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
