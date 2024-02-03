using MediatR;

namespace SchoolManagement.Application.Features.CourseWeeks.Requests.Queries
{
    public class GetDataForPrintWeeklyRoutineFromSpRequest : IRequest<object>
    {
        public int CourseWeekId { get; set; }
    }
}
