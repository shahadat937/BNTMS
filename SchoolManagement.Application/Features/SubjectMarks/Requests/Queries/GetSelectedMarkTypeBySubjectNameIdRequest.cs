using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Queries
{
    public class GetSelectedMarkTypeBySubjectNameIdRequest : IRequest<List<SelectedModel>>
    {
        public int BnaSubjectNameId { get; set; } 
    }
}

  