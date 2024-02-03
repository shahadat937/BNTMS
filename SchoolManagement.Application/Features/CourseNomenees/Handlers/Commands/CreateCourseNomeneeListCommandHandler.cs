using AutoMapper; 
using SchoolManagement.Application.Features.CourseNomenees.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Constants;
using SchoolManagement.Application.Features.Attendances.Requests.Commands;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Commands;

namespace SchoolManagement.Application.Features.CourseNomenees.Handlers.Commands
{
    public class CreateCourseNomeneeListCommandHandler : IRequestHandler<CreateCourseNomeneeListCommand, BaseCommandResponse>
   {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseNomeneeListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseNomeneeListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var trainee = request.CourseListNomeneeDto;

            var traineeList = trainee.SubjectSectionForm.Select(x => new CourseNomenee()
            {
                TraineeNominationId = x.TraineeNominationId,
                BnaSemesterId = x.BnaSemesterId,
                BnaSubjectCurriculumId = x.BnaSubjectCurriculumId,
                BnaSubjectNameId = x.BnaSubjectNameId,
                CourseDurationId = x.CourseDurationId,
                CourseNameId = x.CourseNameId,
                CourseSectionId = x.CourseSectionId,
                DepartmentId = x.DepartmentId,
                TraineeId = x.TraineeId, 
                
            });
            try
            {
                foreach (var item in traineeList)
                {
                    await _unitOfWork.Repository<CourseNomenee>().Add(item);
                    await _unitOfWork.Save();

                    //await _unitOfWork.Repository<CourseNomenee>().Add(item);
                    //await _unitOfWork.Save();
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



/*{
private readonly IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;

public CreateCourseNomeneeListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
{
    _unitOfWork = unitOfWork;
    _mapper = mapper;
}

public async Task<BaseCommandResponse> Handle(CreateCourseNomeneeListCommand request, CancellationToken cancellationToken)
{
    var response = new BaseCommandResponse();

    var attendances = _mapper.Map<List<CourseNomenee>>(request.CourseListNomeneeDto);

    foreach (var item in attendances)
    {
        await _unitOfWork.Repository<CourseNomenee>().Add(item);
        await _unitOfWork.Save();
    }


    response.Success = true;
    response.Message = "Creation Successful";

    return response;
}
}*/

