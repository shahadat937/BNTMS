using MediatR;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetCurrentRoutineInfoBySpRequest : IRequest<object>
    {
        public DateTime? CurrentDate { get; set; }
        public int? BaseSchoolNameId { get; set; }
    }
}
