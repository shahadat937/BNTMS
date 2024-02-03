using MediatR;
using SchoolManagement.Application.DTOs.NewEntryEvaluation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Commands
{
    public class UpdateNewEntryEvaluationCommand : IRequest<Unit>
    {
        public NewEntryEvaluationDto NewEntryEvaluationDto { get; set; }
    }
}
