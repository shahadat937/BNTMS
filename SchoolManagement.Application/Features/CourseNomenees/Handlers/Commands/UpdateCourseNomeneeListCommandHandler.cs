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
using SchoolManagement.Shared.Models;
using System.Net.Sockets;

namespace SchoolManagement.Application.Features.CourseNomenees.Handlers.Commands
{
    public class UpdateCourseNomeneeListCommandHandler : IRequestHandler<UpdateCourseNomeneeListCommand, BaseCommandResponse>
    {

        private readonly ISchoolManagementRepository<TraineeNomination> _TraineeNominationRepository;
        private readonly ISchoolManagementRepository<CourseNomenee> _CourseNomeneeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseNomeneeListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISchoolManagementRepository<TraineeNomination> TraineeNominationRepository, ISchoolManagementRepository<CourseNomenee> courseNomeneeRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _TraineeNominationRepository = TraineeNominationRepository;
            _CourseNomeneeRepository = courseNomeneeRepository;
        }

        public async Task<BaseCommandResponse> Handle(UpdateCourseNomeneeListCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            List<CourseNomenee> CourseNomenees = new List<CourseNomenee>();
            int? traineeId = _TraineeNominationRepository.Where(x => x.TraineeNominationId == request.CourseListNomeneeDto.TraineeNominationId).Select(x => x.TraineeId).FirstOrDefault();
            int? courseDurationId = _TraineeNominationRepository.Where(x => x.TraineeNominationId == request.CourseListNomeneeDto.TraineeNominationId).Select(x => x.CourseDurationId).FirstOrDefault();

            IQueryable<CourseNomenee> courseNomenees = _CourseNomeneeRepository.Where(x => x.TraineeNominationId == request.CourseListNomeneeDto.TraineeNominationId);

            foreach (var item in request.CourseListNomeneeDto.SubjectSectionForm)
            {
                if (item.CourseSectionId != null)
                {
                    foreach (var courseNomenee in courseNomenees)
                    {
                        if (courseNomenee.CourseNameId == request.CourseListNomeneeDto.CourseNameId && courseNomenee.BaseSchoolNameId == request.CourseListNomeneeDto.BaseSchoolNameId && courseNomenee.BnaSemesterId == request.CourseListNomeneeDto.BnaSemesterId && courseNomenee.BnaSubjectCurriculumId == request.CourseListNomeneeDto.BnaSubjectCurriculumId && courseNomenee.BnaSubjectNameId == item.BnaSubjectNameId)
                        {
                            CourseNomenee courseNomeeneeList = new CourseNomenee
                            {
                                TraineeNominationId = request.CourseListNomeneeDto.TraineeNominationId,
                                CourseDurationId = courseDurationId,
                                CourseNameId = request.CourseListNomeneeDto.CourseNameId,
                                BaseSchoolNameId = request.CourseListNomeneeDto.BaseSchoolNameId,
                                CourseModuleId = request.CourseListNomeneeDto.CourseModuleId,
                                BnaSemesterId = request.CourseListNomeneeDto.BnaSemesterId,
                                DepartmentId = request.CourseListNomeneeDto.DepartmentId,
                                BnaSubjectCurriculumId = request.CourseListNomeneeDto.BnaSubjectCurriculumId,
                                BnaSubjectNameId = item.BnaSubjectNameId,
                                CourseSectionId = item.CourseSectionId,
                                TraineeId = traineeId,
                                SubjectMarkId = request.CourseListNomeneeDto.SubjectMarkId,
                                MarkTypeId = request.CourseListNomeneeDto.MarkTypeId,
                                ExamMarkEntry = request.CourseListNomeneeDto.ExamMarkEntry,
                            };
                            var CourseNomenee = await _unitOfWork.Repository<CourseNomenee>().Get(courseNomenee.CourseNomeneeId);
                            _mapper.Map(courseNomeeneeList, CourseNomenee);

                            await _unitOfWork.Repository<CourseNomenee>().Update(CourseNomenee);
                            await _unitOfWork.Save();
                        }
                    }
                }
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

