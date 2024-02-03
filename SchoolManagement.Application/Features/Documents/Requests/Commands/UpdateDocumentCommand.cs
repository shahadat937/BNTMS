using MediatR;
using SchoolManagement.Application.DTOs.Document;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Documents.Requests.Commands
{
    public class UpdateDocumentCommand : IRequest<Unit>
    {
        public CreateDocumentDto CreateDocumentDto { get; set; }
    }
}
