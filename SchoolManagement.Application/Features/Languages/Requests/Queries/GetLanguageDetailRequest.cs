using MediatR;
using SchoolManagement.Application.DTOs.Languages;

namespace SchoolManagement.Application.Features.Languages.Requests.Queries
{
    public class GetLanguageDetailRequest : IRequest<LanguageDto> 
    {
        public int Id { get; set; } 
    }
}
