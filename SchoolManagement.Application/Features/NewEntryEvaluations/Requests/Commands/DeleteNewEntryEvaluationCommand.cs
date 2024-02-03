using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Commands
{
    public class DeleteNewEntryEvaluationCommand : IRequest
    {
        public int NewEntryEvaluationId { get; set; }
    }
}
