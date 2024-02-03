using MediatR;
using SchoolManagement.Application.DTOs.SaylorRank;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SaylorRanks.Requests.Queries
{
    public class GetSaylorRankDetailRequest : IRequest<SaylorRankDto>
    {
        public int SaylorRankId { get; set; }
    }
}
