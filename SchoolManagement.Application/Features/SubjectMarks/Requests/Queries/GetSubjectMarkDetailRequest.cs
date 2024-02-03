using MediatR;
using SchoolManagement.Application.DTOs.SubjectMark;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Queries
{
    public class GetSubjectMarkDetailRequest : IRequest<SubjectMarkDto>
    {
        public int Id { get; set; }
    }
}
