using MediatR;
using SchoolManagement.Application.DTOs.DocumentTypes;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DocumentTypes.Requests.Commands
{
    public class CreateDocumentTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateDocumentTypeDto DocumentTypeDto { get; set; }
    }
}
 