using SchoolManagement.Application.DTOs.TraineeMembership;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeMemberships.Requests.Commands
{
    public class UpdateTraineeMembershipCommand : IRequest<Unit>
    {
        public TraineeMembershipDto TraineeMembershipDto { get; set; }

    }
}
