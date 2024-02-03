using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetRoutineInfoBySchoolIdSpRequest : IRequest<object>
    {
        public int CourseNameId { get; set; }
        public int BaseSchoolNameId { get; set; }
    }
}
