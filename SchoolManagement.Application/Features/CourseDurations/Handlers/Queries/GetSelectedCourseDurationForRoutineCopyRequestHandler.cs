using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetSelectedCourseDurationForRoutineCopyRequestHandler : IRequestHandler<GetSelectedCourseDurationForRoutineCopyRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;


        public GetSelectedCourseDurationForRoutineCopyRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository)
        {
            _CourseDurationRepository = CourseDurationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseDurationForRoutineCopyRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseDuration> codeValues =  _CourseDurationRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.IsCompletedStatus == 0, "CourseName");
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CourseName.Course+"_"+x.CourseTitle,
                Value = x.CourseDurationId
            }).ToList();
            return selectModels;
        }
    }
}
