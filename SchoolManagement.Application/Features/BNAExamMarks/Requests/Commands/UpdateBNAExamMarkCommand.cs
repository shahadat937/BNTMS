using SchoolManagement.Application.DTOs.BnaExamMark;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Commands
{
    public class UpdateBnaExamMarkCommand : IRequest<Unit>
    {
        public BnaExamMarkDto BnaExamMarkDto { get; set; }

    }
} 
