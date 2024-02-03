using MediatR;
using SchoolManagement.Application.DTOs.Languages;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Languages.Requests.Commands
{
    public class CreateLanguageCommand : IRequest<BaseCommandResponse> 
    {
        public CreateLanguageDto LanguageDto { get; set; }      

    }
}
