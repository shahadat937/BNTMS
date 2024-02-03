using MediatR;
using SchoolManagement.Application.DTOs.ExamCenterSelection;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamCenterSelections.Requests.Commands
{
    public class CreateExamCenterSelectionCommand : IRequest<BaseCommandResponse>
    {
        public CreateExamCenterSelectionDto ExamCenterSelectionDto { get; set; }
    }
}
 