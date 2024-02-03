using MediatR;
using SchoolManagement.Application.DTOs.InterServiceMark;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceMarks.Requests.Commands
{
    public class CreateInterServiceMarkCommand : IRequest<BaseCommandResponse>
    {
        public CreateInterServiceMarkDto InterServiceMarkDto { get; set; }
    }
}
 