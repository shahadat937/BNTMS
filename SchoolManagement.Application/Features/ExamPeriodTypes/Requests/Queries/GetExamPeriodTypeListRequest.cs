using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ExamPeriodTypes;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Queries
{
   public class GetExamPeriodTypeListRequest : IRequest<PagedResult<ExamPeriodTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
} 
