using MediatR;
using SchoolManagement.Application.DTOs.ExamCenterSelection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamCenterSelections.Requests.Commands
{
    public class UpdateExamCenterSelectionCommand : IRequest<Unit>
    {
        public ExamCenterSelectionDto ExamCenterSelectionDto { get; set; }
    }
}
 