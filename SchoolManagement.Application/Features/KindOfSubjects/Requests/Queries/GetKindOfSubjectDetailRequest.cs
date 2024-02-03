using MediatR;
using SchoolManagement.Application.DTOs.KindOfSubjects;

namespace SchoolManagement.Application.Features.KindOfSubjects.Requests.Queries
{
    public class GetKindOfSubjectDetailRequest : IRequest<KindOfSubjectDto> 
    {
        public int Id { get; set; }
    }
}
