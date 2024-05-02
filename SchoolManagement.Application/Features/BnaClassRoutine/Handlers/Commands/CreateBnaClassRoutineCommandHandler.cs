using AutoMapper;
using MediatR;
using SchoolManagement.Application.Constants;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaClassRoutine.Requests.Commands;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Commands;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassRoutine.Handlers.Commands
{
    public class CreateBnaClassRoutineCommandHandler : IRequestHandler<CreateBnaClassRoutineCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaClassRoutineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaClassRoutineCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            
            List<Domain.BnaClassRoutine> ClassRoutine = new List<Domain.BnaClassRoutine>();
            ClassRoutine = request.BnaClassRoutineDto.perodListForm.Select(x => new Domain.BnaClassRoutine()

            {
                BnaClassRoutineId = request.BnaClassRoutineDto.ClassRoutineId,
                BnaSubjectCurriculumId = request.BnaClassRoutineDto.BnaSubjectCurriculumId,
                DepartmentId = request.BnaClassRoutineDto.DepartmentId,
                CourseModuleId = request.BnaClassRoutineDto.CourseModuleId,
                BnaSemesterId = request.BnaClassRoutineDto.BnaSemesterId,
                ClassPeriodId = x.classPeriodId,
                PeriodFrom = x.PeriodFrom,
                PeriodTo = x.PeriodTo,
                BaseSchoolNameId = request.BnaClassRoutineDto.BaseSchoolNameId,
                ClassCountPeriod = x.classCountPeriod,
                SubjectCountPeriod = x.subjectCountPeriod,
                CourseNameId = request.BnaClassRoutineDto.CourseNameId,
                WeekID = request.BnaClassRoutineDto.CourseWeekId,
                SubjectMarkId = x.subjectMarkId,
                MarkTypeId = x.markTypeId,
                TraineeId = x.traineeId,
                CourseSectionId = request.BnaClassRoutineDto.CourseSectionId,
                CourseDurationId = request.BnaClassRoutineDto.CourseDurationId,
                BranchId = request.BnaClassRoutineDto.BranchId,
                BnaSubjectNameId = x.subjectId,
                AttendanceComplete = CompleteStatus.NotCompleted,
                ClassLocation = request.BnaClassRoutineDto.ClassLocation,
                TimeDuration = request.BnaClassRoutineDto.TimeDuration,
                ClassRoomName = x.classRoomName,
                ClassTopic = x.classTopic,
                Remarks = request.BnaClassRoutineDto.Remarks,
                Date = request.BnaClassRoutineDto.Date.Value.AddDays(1.0),
                ClassTypeId = x.classTypeId,
                ResultSubmissionStatus = 0,
                FinalApproveStatus = 0,
                ExamMarkComplete = 0,


            }).ToList();

            await _unitOfWork.Repository<Domain.BnaClassRoutine>().AddRangeAsync(ClassRoutine);

            try
            {
                await _unitOfWork.Save();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



            response.Success = true;

            return response;
        }
    }
}