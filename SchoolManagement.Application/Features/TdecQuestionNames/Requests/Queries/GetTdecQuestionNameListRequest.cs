using MediatR;
using SchoolManagement.Application.DTOs.TdecQuestionName;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecQuestionNames.Requests.Queries
{
   public class GetTdecQuestionNameListRequest : IRequest<PagedResult<TdecQuestionNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
