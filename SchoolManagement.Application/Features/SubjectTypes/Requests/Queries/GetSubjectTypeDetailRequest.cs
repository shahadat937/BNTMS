using MediatR;
using SchoolManagement.Application.DTOs.SubjectTypes;

namespace SchoolManagement.Application.Features.SubjectTypes.Requests.Queries
{
    public class GetSubjectTypeDetailRequest : IRequest<SubjectTypeDto>
    {
        public int SubjectTypeId { get; set; }
    }
}
