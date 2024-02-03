using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Districts.Requests.Commands
{
    public class DeleteDistrictCommand : IRequest
    {
        public int DistrictId { get; set; }
    }
}
