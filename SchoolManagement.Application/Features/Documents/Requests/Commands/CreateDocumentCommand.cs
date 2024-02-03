using MediatR;
using SchoolManagement.Application.DTOs.Document;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Documents.Requests.Commands
{
    public class CreateDocumentCommand : IRequest<BaseCommandResponse>
    {
        public CreateDocumentDto DocumentDto { get; set; }
    }
}
