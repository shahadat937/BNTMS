using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Queries
{
    public class GetSelectedBnaCourseWeekRequestHandler : IRequestHandler<GetSelectedBnaCourseWeekRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseWeek> _CourseWeekRepository;
        private readonly ISchoolManagementRepository<BnaSemesterDuration> _BnaSemesterDurationRepository;


        public GetSelectedBnaCourseWeekRequestHandler(ISchoolManagementRepository<CourseWeek> CourseWeekRepository, ISchoolManagementRepository<BnaSemesterDuration> BnaSemesterDurationRepository)
        {
            _CourseWeekRepository = CourseWeekRepository;
            _BnaSemesterDurationRepository = BnaSemesterDurationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaCourseWeekRequest request, CancellationToken cancellationToken)
        {
            //var BnaSemesterDuration = _BnaSemesterDurationRepository.FinedOneInclude(x => x.BnaSemesterDurationId == request.BnaSemesterDurationId);

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
