using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Queries
{
    public class GetSelectedClassPeriodByParametersFromClassRoutineRequest : IRequest<List<SelectedModel>>
    { 
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; } 
        public int CourseDurationId { get; set; } 
        public DateTime Date { get; set; }
    }
}

 