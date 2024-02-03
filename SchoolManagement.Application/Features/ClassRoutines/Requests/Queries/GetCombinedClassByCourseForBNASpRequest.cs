using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetCombinedClassByCourseForBNASpRequest : IRequest<object>
    {
        public DateTime CurrentDate { get; set; } 
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
    }
}  
 