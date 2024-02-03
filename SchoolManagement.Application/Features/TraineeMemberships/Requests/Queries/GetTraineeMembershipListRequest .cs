using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeMembership;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeMemberships.Requests.Queries
{
    public class GetTraineeMembershipListRequest : IRequest<PagedResult<TraineeMembershipDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
