using MediatR;
using SchoolManagement.Application.DTOs.Document;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Documents.Requests.Queries
{
    public class GetDocumentDetailRequest : IRequest<DocumentDto>
    {
        public int DocumentId { get; set; }
    }
}
