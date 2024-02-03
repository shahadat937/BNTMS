using SchoolManagement.Application.DTOs.TraineeMembership;
using MediatR;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.TraineeMemberships.Requests.Queries
{
    public class GetTraineeMembershipListByTraineeRequest : IRequest<List<TraineeMembershipDto>>
    {
        public int Traineeid { get; set; }
    }
}
