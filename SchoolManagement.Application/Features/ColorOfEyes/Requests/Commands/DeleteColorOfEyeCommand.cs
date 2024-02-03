using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ColorOfEyes.Requests.Commands
{
    public class DeleteColorOfEyeCommand : IRequest
    {
        public int ColorOfEyesId { get; set; }
    }
}
