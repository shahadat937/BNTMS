using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetRoutineListForRoutineNoteRequest : IRequest<List<SelectedModel>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }   
        public int CourseDurationId { get; set; } 
        public int CourseWeekId { get; set; } 
    }
}

 