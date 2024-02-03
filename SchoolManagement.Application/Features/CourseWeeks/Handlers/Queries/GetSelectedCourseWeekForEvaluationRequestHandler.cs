using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Queries
{
    public class GetSelectedCourseWeekForEvaluationRequestHandler : IRequestHandler<GetSelectedCourseWeekForEvaluationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseWeek> _CourseWeekRepository;


        public GetSelectedCourseWeekForEvaluationRequestHandler(ISchoolManagementRepository<CourseWeek> CourseWeekRepository)
        {
            _CourseWeekRepository = CourseWeekRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseWeekForEvaluationRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseWeek> CourseWeeks = await _CourseWeekRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = CourseWeeks.Select(x => new SelectedModel 
            {
                Text = x.WeekName,
                Value = x.CourseWeekId
            }).ToList();
            return selectModels;
        }
    }
}
