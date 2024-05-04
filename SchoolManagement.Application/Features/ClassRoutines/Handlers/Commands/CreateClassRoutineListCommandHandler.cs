using AutoMapper;
using SchoolManagement.Application.DTOs.ClassRoutine.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;
using SchoolManagement.Application.Constants;
using System.Collections;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Commands
{
    public class CreateClassRoutineListCommandHandler : IRequestHandler<CreateClassRoutineListCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateClassRoutineListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateClassRoutineListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            //var validator = new CreateClassRoutineDtoValidator();
            //var validationResult = await validator.ValidateAsync(request.ClassRoutineDto);

            //if (validationResult.IsValid == false)
            //{
            //    response.Success = false;
            //    response.Message = "Creation Failed";
            //    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            //}
            //else
            //{
            //var ClassRoutines = request.ClassRoutineDto;

            //foreach (var item in ClassRoutines.perodListForm)
            //{
            //    //if (item.AttendanceStatus == null)
            //    //{
            //    //    item.AttendanceStatus = false;
            //    //}
            //}
            List<ClassRoutine> ClassRoutine = new List<ClassRoutine>();
            ClassRoutine = request.ClassRoutineDto.perodListForm.Select(x => new ClassRoutine()

           //IList ClassRoutines = request.ClassRoutineDto.perodListForm.Select(x => new ClassRoutine()
                {
                    ClassRoutineId = request.ClassRoutineDto.ClassRoutineId,
                    CourseModuleId = request.ClassRoutineDto.CourseModuleId,
                    ClassPeriodId = x.classPeriodId,
                    BaseSchoolNameId = request.ClassRoutineDto.BaseSchoolNameId,
                    ClassCountPeriod = x.classCountPeriod,
                    SubjectCountPeriod = x.subjectCountPeriod,
                    CourseNameId = request.ClassRoutineDto.CourseNameId,
                    CourseWeekId = request.ClassRoutineDto.CourseWeekId,
                    SubjectMarkId = x.subjectMarkId,
                    MarkTypeId = x.markTypeId,
                    TraineeId = x.traineeId,
                    CourseSectionId = request.ClassRoutineDto.CourseSectionId,
                    CourseDurationId = request.ClassRoutineDto.CourseDurationId,
                    BranchId = request.ClassRoutineDto.BranchId,
                    BnaSubjectNameId = x.subjectId,
                    AttendanceComplete = CompleteStatus.NotCompleted,
                    ClassLocation = request.ClassRoutineDto.ClassLocation,
                    TimeDuration = request.ClassRoutineDto.TimeDuration,
                    ClassRoomName = x.classRoomName,
                    ClassTopic = x.classTopic,
                    Remarks = request.ClassRoutineDto.Remarks,
                    Date = request.ClassRoutineDto.Date.Value.AddDays(1.0),
                    ClassTypeId = x.classTypeId,                 
                    ResultSubmissionStatus = 0,
                    FinalApproveStatus = 0,
                  
                }).ToList();
               // var ClassRoutines = _mapper.Map<ClassRoutine>(request.ClassRoutineDto);
              
               //ClassRoutines.Date = ClassRoutines.Date.Value.AddDays(1.0);

               //ClassRoutines.AttendanceComplete = CompleteStatus.NotCompleted;
               //ClassRoutines.ResultSubmissionStatus = 0;
               //ClassRoutines.FinalApproveStatus = 0;
                
                await _unitOfWork.Repository<ClassRoutine>().AddRangeAsync(ClassRoutine);

                try
                {
                    await _unitOfWork.Save();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                

                response.Success = true;
                response.Message = "Creation Successful";
               // response.Id = ClassRoutines.ClassRoutineId;
          //  }

            return response;
        }
    }
}
