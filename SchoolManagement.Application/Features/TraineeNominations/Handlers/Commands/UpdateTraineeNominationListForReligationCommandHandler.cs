using AutoMapper;
using SchoolManagement.Application.Features.Attendances.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Constants;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Commands;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Commands
{
    public class UpdateTraineeNominationListForReligationCommandHandler : IRequestHandler<UpdateTraineeNominationListForReligationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTraineeNominationListForReligationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateTraineeNominationListForReligationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var trainee = request.TraineeNominationList;

            var traineeList = trainee.traineeListForms.Select(x => new TraineeNomination()
            {
                //TraineeNominationId = x.traineeNominationId,
                //IndexNo = x.indexNo,
                //CourseSectionId = x.CourseSectionId,
                //CourseDurationId = x.CourseDurationId,
                //CourseNameId = x.CourseNameId,
                //TraineeId = x.TraineeId,
                //PresentBillet = x.PresentBillet,
                //DateCreated = x.DateCreated,
                //CreatedBy = x.CreatedBy,
                //ExamAttemptTypeId =x.ExamAttemptTypeId,
                // ExamTypeId =x.ExamTypeId,
                // TraineeCourseStatusId=x.TraineeCourseStatusId,
                // WithdrawnDocId=x.WithdrawnDocId,
                // ExamCenterId=x.ExamCenterId,
                // NewAtemptId=x.NewAtemptId,
                // FamilyAllowId=x.FamilyAllowId,
                // WithdrawnRemarks=x.WithdrawnRemarks,
                // WithdrawnDate=x.WithdrawnDate,
                // Status=x.Status,
                // MenuPosition=x.MenuPosition,
                // IsActive=x.IsActive
            });
            try
            {
                foreach (var item in traineeList)
                {
                    await _unitOfWork.Repository<TraineeNomination>().Update(item);
                    await _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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
