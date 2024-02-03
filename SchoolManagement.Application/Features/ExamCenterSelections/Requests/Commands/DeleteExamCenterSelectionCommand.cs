using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamCenterSelections.Requests.Commands
{
    public class DeleteExamCenterSelectionCommand : IRequest
    {
        public int ExamCenterSelectionId { get; set; }
    }
}
 