using MediatR;
using SchoolManagement.Application.DTOs.NewEntryEvaluation;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Queries
{
   public class GetNewEntryEvaluationListRequest : IRequest<PagedResult<NewEntryEvaluationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
