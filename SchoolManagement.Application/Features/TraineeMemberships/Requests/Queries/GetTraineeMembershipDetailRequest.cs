using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeMembership;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeMemberships.Requests.Queries
{
    public class GetTraineeMembershipDetailRequest : IRequest<TraineeMembershipDto>
    {
        public int TraineeMembershipId { get; set; }
    }
}
