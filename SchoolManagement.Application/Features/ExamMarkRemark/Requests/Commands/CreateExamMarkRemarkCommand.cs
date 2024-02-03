using MediatR;
using SchoolManagement.Application.DTOs.ExamMarkRemarks;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamMarkRemark.Requests.Commands
{
    public class CreateExamMarkRemarkCommand : IRequest<BaseCommandResponse>
    {
        public CreateExamMarkRemarkDto ExamMarkRemarkDto { get; set; }
    }
}
