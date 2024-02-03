using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TrainingObjectives.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TrainingObjectives.Handlers.Queries
{
    public class GetSelectedSubjectNameFromTrainingObjectiveBySchoolIdAndCourseNameIdRequestHandler : IRequestHandler<GetSelectedSubjectNameFromTrainingObjectiveBySchoolIdAndCourseNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TrainingObjective> _TrainingObjectiveRepository;


        public GetSelectedSubjectNameFromTrainingObjectiveBySchoolIdAndCourseNameIdRequestHandler(ISchoolManagementRepository<TrainingObjective> TrainingObjectiveRepository)
        {
            _TrainingObjectiveRepository = TrainingObjectiveRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSubjectNameFromTrainingObjectiveBySchoolIdAndCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<TrainingObjective> TrainingObjectives = _TrainingObjectiveRepository.FilterWithInclude((x => x.IsActive && x.BaseSchoolNameId==request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId ), "BnaSubjectName");
            List<SelectedModel> selectModels = TrainingObjectives.Select(x => new SelectedModel 
            {
                Text = x.BnaSubjectName.SubjectName,
                Value = x.BnaSubjectNameId
            }).ToList();
            return selectModels;
        }
    }
}
