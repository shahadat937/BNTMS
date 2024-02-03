using AutoMapper;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Commands
{
    public class CreateBnaExamMarkListCommandHandler : IRequestHandler<CreateBnaExamMarkListCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaExamMarkListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaExamMarkListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            //var BnaExamMarks = _mapper.Map<List<BnaExamMark>>(request.BnaExamMarkListDto);
            var BnaExamMarks = request.BnaExamMarkListDto;

            if( BnaExamMarks.SchoolDb == 1)
            {
                var bnaExamMarkList = BnaExamMarks.traineeListForm.Select(x => new BnaExamMark()
                {
                    BaseSchoolNameId = BnaExamMarks.BaseSchoolNameId,
                    CourseNameId = BnaExamMarks.CourseNameId,
                    BnaSubjectNameId = BnaExamMarks.BnaSubjectNameId,
                    SubjectMarkId = BnaExamMarks.SubjectMarkId,
                    TraineeNominationId = x.TraineeNominationId,
                    BnaExamScheduleId = BnaExamMarks.BnaExamScheduleId,
                    BnaSemesterId = BnaExamMarks.BnaSemesterId,
                    BnaBatchId = BnaExamMarks.BnaBatchId,
                    BranchId = BnaExamMarks.BranchId,
                    ClassRoutineId = BnaExamMarks.ClassRoutineId,
                    CourseDurationId = BnaExamMarks.CourseDurationId,
                    BnaCurriculumTypeId = BnaExamMarks.BnaCurriculamTypeId,
                    TotalMark = BnaExamMarks.TotalMark,
                    PassMark = BnaExamMarks.PassMark,
                    IsApproved = BnaExamMarks.IsApproved,
                    IsApprovedBy = BnaExamMarks.IsApprovedBy,
                    IsApprovedDate = BnaExamMarks.IsApprovedDate,
                    Remarks = BnaExamMarks.Remarks,
                    Status = BnaExamMarks.Status,
                    SubmissionStatus = 1,
                    IsActive = BnaExamMarks.IsActive,
                    CourseSectionId = BnaExamMarks.CourseSectionId,
                    ReExamStatus = BnaExamMarks.ReExamStatus,
                    ObtaintMark = x.ObtaintMark,
                    ResultStatus = x.ResultStatus,
                    TraineeId = x.TraineeId,
                    ExamMarkRemarksId = x.ExamMarkRemarksId,
                });

                await _unitOfWork.Repository<BnaExamMark>().AddRangeAsync(bnaExamMarkList);
                await _unitOfWork.Save();



                var routines = await _unitOfWork.Repository<ClassRoutine>().Get(bnaExamMarkList.Select(x => BnaExamMarks.ClassRoutineId).FirstOrDefault().Value);

                if (BnaExamMarks.ExamTypeCount == 1)
                {
                    routines.ExamMarkComplete = 1;
                    routines.ResultSubmissionStatus = 1;
                    await _unitOfWork.Repository<ClassRoutine>().Update(routines);
                    await _unitOfWork.Save();
                }
                else
                {
                    routines.ExamMarkComplete = 0;
                    await _unitOfWork.Repository<ClassRoutine>().Update(routines);
                    await _unitOfWork.Save();
                }

            }

            //For Assignment Mark Submission 
           else if (BnaExamMarks.SchoolDb == 2)
            {
                var bnaExamMarkList = BnaExamMarks.traineeListForm.Select(x => new BnaExamMark()
                {
                    BaseSchoolNameId = BnaExamMarks.BaseSchoolNameId,
                    CourseNameId = BnaExamMarks.CourseNameId,
                    BnaSubjectNameId = BnaExamMarks.BnaSubjectNameId,
                    SubjectMarkId = BnaExamMarks.SubjectMarkId,
                    TraineeNominationId = x.TraineeNominationId,
                    BnaExamScheduleId = BnaExamMarks.BnaExamScheduleId,
                    BnaSemesterId = BnaExamMarks.BnaSemesterId,
                    BnaBatchId = BnaExamMarks.BnaBatchId,
                    BranchId = BnaExamMarks.BranchId,
                    ClassRoutineId = BnaExamMarks.ClassRoutineId,
                    CourseDurationId = BnaExamMarks.CourseDurationId,
                    BnaCurriculumTypeId = BnaExamMarks.BnaCurriculamTypeId,
                    TotalMark = BnaExamMarks.TotalMark,
                    PassMark = BnaExamMarks.PassMark,
                    IsApproved = BnaExamMarks.IsApproved,
                    IsApprovedBy = BnaExamMarks.IsApprovedBy,
                    IsApprovedDate = BnaExamMarks.IsApprovedDate,
                    Remarks = BnaExamMarks.Remarks,
                    Status = BnaExamMarks.Status,
                    SubmissionStatus = 1,
                    IsActive = BnaExamMarks.IsActive,
                    CourseSectionId = BnaExamMarks.CourseSectionId,
                    ReExamStatus = BnaExamMarks.ReExamStatus,
                    ObtaintMark = x.ObtaintMark,
                    ResultStatus = x.ResultStatus,
                    TraineeId = x.TraineeId,
                    ExamMarkRemarksId = x.ExamMarkRemarksId,
                });

                await _unitOfWork.Repository<BnaExamMark>().AddRangeAsync(bnaExamMarkList);
                await _unitOfWork.Save();
            }

            else
            {
                var bnaExamMarkList = BnaExamMarks.traineeListForm.Select(x => new BnaExamMark()
                {
                    BaseSchoolNameId = BnaExamMarks.BaseSchoolNameId,
                    CourseNameId = BnaExamMarks.CourseNameId,
                    BnaSubjectNameId = BnaExamMarks.BnaSubjectNameId,
                    SubjectMarkId = BnaExamMarks.SubjectMarkId,
                    BnaExamScheduleId = BnaExamMarks.BnaExamScheduleId,
                    BnaSemesterId = BnaExamMarks.BnaSemesterId,
                    TraineeNominationId = x.TraineeNominationId,
                    BnaBatchId = BnaExamMarks.BnaBatchId,
                    BranchId = BnaExamMarks.BranchId,
                    ClassRoutineId = BnaExamMarks.ClassRoutineId,
                    CourseDurationId = BnaExamMarks.CourseDurationId,
                    BnaCurriculumTypeId = BnaExamMarks.BnaCurriculamTypeId,
                    TotalMark = BnaExamMarks.TotalMark,
                    PassMark = BnaExamMarks.PassMark,
                    IsApproved = BnaExamMarks.IsApproved,
                    IsApprovedBy = BnaExamMarks.IsApprovedBy,
                    IsApprovedDate = BnaExamMarks.IsApprovedDate,
                    ReExamStatus = BnaExamMarks.ReExamStatus,
                    Remarks = BnaExamMarks.Remarks,
                    Status = BnaExamMarks.Status,
                    SubmissionStatus = 0,
                    IsActive = BnaExamMarks.IsActive,
                    ObtaintMark = x.ObtaintMark,
                    ResultStatus = x.ResultStatus,
                    TraineeId = x.TraineeId,
                    ExamMarkRemarksId = x.ExamMarkRemarksId,
                    CourseSectionId = BnaExamMarks.CourseSectionId,
                });

                await _unitOfWork.Repository<BnaExamMark>().AddRangeAsync(bnaExamMarkList);
                await _unitOfWork.Save();



                var routines = await _unitOfWork.Repository<ClassRoutine>().Get(bnaExamMarkList.Select(x => BnaExamMarks.ClassRoutineId).FirstOrDefault().Value);

                if (BnaExamMarks.ExamTypeCount == 1)
                {
                    routines.ExamMarkComplete = 1;
                    await _unitOfWork.Repository<ClassRoutine>().Update(routines);
                    await _unitOfWork.Save();
                }
                else
                {
                    routines.ExamMarkComplete = 0;
                    await _unitOfWork.Repository<ClassRoutine>().Update(routines);
                    await _unitOfWork.Save();
                }
            }

            //Attendance For Sick
            if (BnaExamMarks.IsAbsent == true)
            {
                var attendanceStatus = BnaExamMarks.traineeListForm.Select(x => new Attendance()
                {
                    AttendanceStatus = x.AttendanceStatus,
                    AttendanceId = x.AttendanceId.Value
                }).Where(x => x.AttendanceStatus == false && BnaExamMarks.ReExamStatus == 0);

                if (attendanceStatus.Any(x => x.AttendanceStatus == false))
                {
                    foreach (var item in attendanceStatus)
                    {
                        var attendance = await _unitOfWork.Repository<Attendance>().Get(item.AttendanceId);
                        attendance.AbsentForExamStatus = false;
                        //_mapper.Map(request.AllowanceDto, Allowance);

                        await _unitOfWork.Repository<Attendance>().Update(attendance);
                        await _unitOfWork.Save();
                    }
                }
            }
            //routines.ExamMarkComplete = 1;

            //await _unitOfWork.Repository<ClassRoutine>().Update(routines);
            //await _unitOfWork.Save();


         

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
