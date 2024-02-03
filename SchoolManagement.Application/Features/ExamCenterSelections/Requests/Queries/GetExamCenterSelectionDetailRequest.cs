using MediatR;
using SchoolManagement.Application.DTOs.ExamCenterSelection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamCenterSelections.Requests.Queries
{
    public class GetExamCenterSelectionDetailRequest : IRequest<ExamCenterSelectionDto>
    {
        public int ExamCenterSelectionId { get; set; }
    }
}
 