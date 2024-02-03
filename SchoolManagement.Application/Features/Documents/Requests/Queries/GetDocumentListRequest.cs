using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Document;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Documents.Requests.Queries
{
   public class GetDocumentListRequest : IRequest<PagedResult<DocumentDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
