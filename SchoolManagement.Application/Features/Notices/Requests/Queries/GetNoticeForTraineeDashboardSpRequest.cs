using MediatR;

namespace SchoolManagement.Application.Features.Notices.Requests.Queries
{
    public class GetNoticeForTraineeDashboardSpRequest : IRequest<object>
    {
        public DateTime? CurrentDate { get; set; }
        public int BaseSchoolNameId { get; set; }        
        public int CourseDurationId { get; set; }        
        public int TraineeId { get; set; }        
    }
}
