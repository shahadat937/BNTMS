using MediatR;
using SchoolManagement.Application.DTOs.WithdrawnDoc;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.WithdrawnDocs.Requests.Commands
{
    public class CreateWithdrawnDocsCommand : IRequest<BaseCommandResponse> 
    {
        public CreateWithdrawnDocDto WithdrawnDocDto { get; set; }      

    }
}
