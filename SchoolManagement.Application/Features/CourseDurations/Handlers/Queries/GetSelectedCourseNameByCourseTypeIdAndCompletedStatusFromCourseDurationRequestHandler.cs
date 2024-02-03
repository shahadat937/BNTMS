using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetSelectedCourseNameByCourseTypeIdAndCompletedStatusFromCourseDurationRequestHandler : IRequestHandler<GetSelectedCourseNameByCourseTypeIdAndCompletedStatusFromCourseDurationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;


        public GetSelectedCourseNameByCourseTypeIdAndCompletedStatusFromCourseDurationRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository)
        {
            _CourseDurationRepository = CourseDurationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseNameByCourseTypeIdAndCompletedStatusFromCourseDurationRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseDuration> CourseDurations = _CourseDurationRepository.FilterWithInclude(x => x.IsActive, "CourseName","Country").Where(x =>x.CourseTypeId==18 && x.IsCompletedStatus==0);
            List<SelectedModel> selectModels = CourseDurations.Select(x => new SelectedModel 
            {
                Text = x.CourseName.Course + '_' + x.Country.CountryName,
                Value = x.CourseDurationId
            }).ToList();
            return selectModels;
        }
    }
}
