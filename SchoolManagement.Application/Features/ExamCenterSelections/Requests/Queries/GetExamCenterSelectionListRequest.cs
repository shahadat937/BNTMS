using MediatR;
using SchoolManagement.Application.DTOs.ExamCenterSelection;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamCenterSelections.Requests.Queries
{
   public class GetExamCenterSelectionListRequest : IRequest<PagedResult<ExamCenterSelectionDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 