using MediatR;
using SchoolManagement.Application.DTOs.NewEntryEvaluation;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Commands
{
    public class CreateNewEntryEvaluationCommand : IRequest<BaseCommandResponse>
    {
        public CreateNewEntryEvaluationDto NewEntryEvaluationDto { get; set; }
    }
}
