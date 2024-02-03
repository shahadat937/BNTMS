using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseNameByOrganizationNameIdRequestHandler : IRequestHandler<GetCourseNameByOrganizationNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

          
        public GetCourseNameByOrganizationNameIdRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository)
        {
            _CourseDurationRepository = CourseDurationRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetCourseNameByOrganizationNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseDuration> CourseDurations = _CourseDurationRepository.FilterWithInclude(x => x.OrganizationNameId == request.OrganizationNameId, "CourseName");
            List<SelectedModel> selectModels = CourseDurations.Select(x => new SelectedModel
            {
                Text = x.CourseName.Course, 
                Value =  x.CourseDurationId
            }).ToList();
            return selectModels;
        }
    }
}
