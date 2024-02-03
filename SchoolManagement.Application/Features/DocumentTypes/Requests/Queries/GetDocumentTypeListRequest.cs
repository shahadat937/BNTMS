using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.DocumentTypes;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DocumentTypes.Requests.Queries
{
   public class GetDocumentTypeListRequest : IRequest<PagedResult<DocumentTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
