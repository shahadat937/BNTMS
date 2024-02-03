using SchoolManagement.Application.DTOs.TraineeMembership;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeMemberships.Requests.Commands
{
    public class CreateTraineeMembershipCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeMembershipDto TraineeMembershipDto { get; set; }

    }
}
