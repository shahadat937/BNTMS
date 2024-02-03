using MediatR;
using SchoolManagement.Application.DTOs.NewEntryEvaluation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Queries
{
    public class GetNewEntryEvaluationDetailRequest : IRequest<NewEntryEvaluationDto>
    {
        public int NewEntryEvaluationId { get; set; }
    }
}
