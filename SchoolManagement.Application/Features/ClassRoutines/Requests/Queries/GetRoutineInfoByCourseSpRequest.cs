using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetRoutineInfoByCourseSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
    }
}
