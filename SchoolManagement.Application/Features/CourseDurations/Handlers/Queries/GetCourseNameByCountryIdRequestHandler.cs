using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseNameByCountryIdRequestHandler : IRequestHandler<GetCourseNameByCountryIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

          
        public GetCourseNameByCountryIdRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository)
        {
            _CourseDurationRepository = CourseDurationRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetCourseNameByCountryIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseDuration> CourseDurations = _CourseDurationRepository.FilterWithInclude(x => x.CountryId == request.CountryId, "Country");
            List<SelectedModel> selectModels = CourseDurations.Select(x => new SelectedModel
            {
                Text = x.CourseName.Course, 
                Value =  x.CourseDurationId
            }).ToList();
            return selectModels;
        }
    }
}
