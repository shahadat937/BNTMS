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
        private readonly ISchoolManagementRepository<TraineeNomination> _TraineeNominationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseNomeneeListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISchoolManagementRepository<TraineeNomination> TraineeNominationRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _TraineeNominationRepository = TraineeNominationRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseNomeneeListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            List<CourseNomenee> CourseNomenees = new List<CourseNomenee>();
            int? traineeId = _TraineeNominationRepository.Where(x => x.TraineeNominationId == request.CourseListNomeneeDto.TraineeNominationId).Select(x => x.TraineeId).FirstOrDefault();
            int? courseDurationId = _TraineeNominationRepository.Where(x => x.TraineeNominationId == request.CourseListNomeneeDto.TraineeNominationId).Select(x => x.CourseDurationId).FirstOrDefault();
            CourseNomenees = request.CourseListNomeneeDto.SubjectSectionForm.Select(x => new CourseNomenee()
            {
                CourseNomeneeId = request.CourseListNomeneeDto.CourseNomeneeId,
                TraineeNominationId = request.CourseListNomeneeDto.TraineeNominationId,
                CourseDurationId = courseDurationId,
                CourseNameId = request.CourseListNomeneeDto.CourseNameId,
                BaseSchoolNameId = request.CourseListNomeneeDto.BaseSchoolNameId,
                CourseModuleId = request.CourseListNomeneeDto.CourseModuleId,
                BnaSemesterId = request.CourseListNomeneeDto.BnaSemesterId,
                DepartmentId = request.CourseListNomeneeDto.DepartmentId,
                BnaSubjectCurriculumId = request.CourseListNomeneeDto.BnaSubjectCurriculumId,
                BnaSubjectNameId = x.BnaSubjectNameId,
                CourseSectionId = x.CourseSectionId,
                TraineeId = traineeId,
                SubjectMarkId = request.CourseListNomeneeDto.SubjectMarkId,
                MarkTypeId = request.CourseListNomeneeDto.MarkTypeId,
                ExamMarkEntry = request.CourseListNomeneeDto.ExamMarkEntry,
            }).ToList();

            await _unitOfWork.Repository<CourseNomenee>().AddRangeAsync(CourseNomenees);

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

