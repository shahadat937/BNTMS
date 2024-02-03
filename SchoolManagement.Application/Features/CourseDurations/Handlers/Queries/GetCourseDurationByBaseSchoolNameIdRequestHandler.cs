using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseDurationByBaseSchoolNameIdRequestHandler : IRequestHandler<GetCourseDurationByBaseSchoolNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

         
        public GetCourseDurationByBaseSchoolNameIdRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository)
        {
            _CourseDurationRepository = CourseDurationRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetCourseDurationByBaseSchoolNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseDuration> CourseDurations = await _CourseDurationRepository.FilterAsync(x =>x.BaseSchoolNameId == request.BaseSchoolNameId);
            List<SelectedModel> selectModels = CourseDurations.Select(x => new SelectedModel
            {
                Text = x.CourseTitle,
                Value = x.CourseDurationId
            }).ToList();
            return selectModels;
        }
    }
}
