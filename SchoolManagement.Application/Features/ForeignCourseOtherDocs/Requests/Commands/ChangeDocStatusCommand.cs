using MediatR;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Commands
{
    public class ChangeDocStatusCommand : IRequest
    {
        public int ForeignCourseOtherDocId { get; set; } 
        public string FieldName { get; set; } 
        public bool Status { get; set; }
    }
} 
