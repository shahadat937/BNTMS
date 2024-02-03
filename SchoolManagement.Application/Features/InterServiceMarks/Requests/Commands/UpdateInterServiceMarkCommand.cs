using MediatR;
using SchoolManagement.Application.DTOs.InterServiceMark;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceMarks.Requests.Commands
{
    public class UpdateInterServiceMarkCommand : IRequest<Unit>
    {
        public InterServiceMarkDto InterServiceMarkDto { get; set; }
    }
}
 