using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TrainingObjective;
using SchoolManagement.Application.Features.TrainingObjectives.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TrainingObjectives.Handlers.Queries
{
    public class GetTrainingObjectiveListBySchoolIdCourseNameIdAndSubjectNameIdRequestHandler : IRequestHandler<GetTrainingObjectiveListBySchoolIdCourseNameIdAndSubjectNameIdRequest, List<TrainingObjectiveDto>>
    {
        private readonly ISchoolManagementRepository<TrainingObjective> _TrainingObjectiveRepository;
        private readonly IMapper _mapper;

        public GetTrainingObjectiveListBySchoolIdCourseNameIdAndSubjectNameIdRequestHandler(ISchoolManagementRepository<TrainingObjective> TrainingObjectiveRepository, IMapper mapper)
        {
            _TrainingObjectiveRepository = TrainingObjectiveRepository;
            _mapper = mapper;
        }
         
        public async Task<List<TrainingObjectiveDto>> Handle(GetTrainingObjectiveListBySchoolIdCourseNameIdAndSubjectNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<TrainingObjective> TrainingObjectives = _TrainingObjectiveRepository.FilterWithInclude(x=>x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.BnaSubjectNameId == request.BnaSubjectNameId , "BaseSchoolName", "CourseName", "BnaSubjectName", "CourseTask").ToList();
            
            var TrainingObjectiveDtos = _mapper.Map<List<TrainingObjectiveDto>>(TrainingObjectives);
            return TrainingObjectiveDtos; 
        }
    }
}
