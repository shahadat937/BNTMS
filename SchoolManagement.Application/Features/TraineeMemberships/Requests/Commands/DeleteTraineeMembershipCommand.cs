using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeMemberships.Requests.Commands
{
    public class DeleteTraineeMembershipCommand : IRequest
    {
        public int TraineeMembershipId { get; set; }
    }
}
