using MediatR;

namespace SchoolManagement.Application.Features.Documents.Requests.Queries
{
    public class GetInterserviceDocumentsFromSpRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}
