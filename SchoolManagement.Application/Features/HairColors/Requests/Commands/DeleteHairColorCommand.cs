using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.HairColors.Requests.Commands
{
    public class DeleteHairColorCommand : IRequest
    {
        public int HairColorId { get; set; }
    }
}
