using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;
 
namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetBnaSubjectNameDetailRequest : IRequest<BnaSubjectNameDto> 
    {
        public int Id { get; set; } 
    }
} 
 