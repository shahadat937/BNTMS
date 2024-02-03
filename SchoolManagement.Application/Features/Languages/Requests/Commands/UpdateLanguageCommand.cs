using MediatR;
using SchoolManagement.Application.DTOs.Languages;

namespace SchoolManagement.Application.Features.Languages.Requests.Commands
{
    public class UpdateLanguageCommand : IRequest<Unit>  
    { 
        public LanguageDto LanguageDto { get; set; }     
    }
}
