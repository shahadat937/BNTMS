using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Queries
{
    public class GetSelectedCourseWeekRequestHandler : IRequestHandler<GetSelectedCourseWeekRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseWeek> _CourseWeekRepository;


        public GetSelectedCourseWeekRequestHandler(ISchoolManagementRepository<CourseWeek> CourseWeekRepository)
        {
            _CourseWeekRepository = CourseWeekRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseWeekRequest request, CancellationToken cancellationToken)
        {
            
            ICollection<CourseWeek> codeValues = await _CourseWeekRepository.FilterAsync(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseDurationId == request.CourseDurationId && x.CourseNameId == request.CourseNameId && x.Status == (request.Status == 100 ? x.Status : 0));

            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                    Text = x.WeekName,
                    Value = x.CourseWeekId
            }).ToList();
            
            return selectModels;
            
        }
    }
}
