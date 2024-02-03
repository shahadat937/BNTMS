using MediatR;
using SchoolManagement.Application.DTOs.SubjectClassifications;

namespace SchoolManagement.Application.Features.SubjectClassifications.Requests.Queries
{
    public class GetSubjectClassificationDetailRequest : IRequest<SubjectClassificationDto>
    {
        public int SubjectClassificationId { get; set; }
    }
}
