using MediatR;
using SchoolManagement.Application.DTOs.SaylorRank;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SaylorRanks.Requests.Commands
{
    public class UpdateSaylorRankCommand : IRequest<Unit>
    {
        public SaylorRankDto SaylorRankDto { get; set; }
    }
}
