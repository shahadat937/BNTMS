using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseNameBySchoolNameIdRequestHandler : IRequestHandler<GetCourseNameBySchoolNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

          
        public GetCourseNameBySchoolNameIdRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository)
        {
            _CourseDurationRepository = CourseDurationRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetCourseNameBySchoolNameIdRequest request, CancellationToken cancellationToken)
        {
            //ICollection<CourseDuration> CourseDurations = await _CourseDurationRepository.FilterAsync(x =>x.BaseSchoolNameId == request.BaseSchoolNameId);
            IQueryable<CourseDuration> CourseDurations = _CourseDurationRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId, "CourseName");
            List<SelectedModel> selectModels = CourseDurations.Select(x => new SelectedModel
            {
                Text = x.CourseName.Course + "_" + x.CourseTitle, 
                Value = x.CourseNameId+ "_" + x.CourseDurationId
            }).ToList();
            return selectModels;
        }
    }
}
