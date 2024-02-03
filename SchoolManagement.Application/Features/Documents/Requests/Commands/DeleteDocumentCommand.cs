using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Documents.Requests.Commands
{
    public class DeleteDocumentCommand : IRequest
    {
        public int DocumentId { get; set; }
    }
}
