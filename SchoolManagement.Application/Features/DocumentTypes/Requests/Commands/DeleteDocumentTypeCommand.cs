using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DocumentTypes.Requests.Commands
{
    public class DeleteDocumentTypeCommand : IRequest
    {
        public int DocumentTypeId { get; set; }
    }
}
