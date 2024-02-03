using MediatR;
using SchoolManagement.Application.DTOs.BaseNames;
 
namespace SchoolManagement.Application.Features.BaseNames.Requests.Queries
{
    public class GetBaseNameDetailRequest : IRequest<BaseNameDto> 
    {
        public int Id { get; set; } 
    }
} 
