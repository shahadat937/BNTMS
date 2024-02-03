using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetSelectedCourseDurationByCourseTypeIdRequestHandler : IRequestHandler<GetSelectedCourseDurationByCourseTypeIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;


        public GetSelectedCourseDurationByCourseTypeIdRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository)
        {
            _CourseDurationRepository = CourseDurationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseDurationByCourseTypeIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseDuration> codeValues =  _CourseDurationRepository.FilterWithInclude(x => x.CourseTypeId == request.CourseTypeId && x.IsCompletedStatus == 0, "CourseName");
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CourseName.Course+"_"+x.CourseTitle,
                Value = x.CourseDurationId+ "_" + x.CourseNameId
            }).ToList();
            return selectModels;
        }
    }
}
