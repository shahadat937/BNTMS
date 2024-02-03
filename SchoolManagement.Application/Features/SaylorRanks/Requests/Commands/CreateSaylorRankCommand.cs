using MediatR;
using SchoolManagement.Application.DTOs.SaylorRank;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SaylorRanks.Requests.Commands
{
    public class CreateSaylorRankCommand : IRequest<BaseCommandResponse>
    {
        public CreateSaylorRankDto SaylorRankDto { get; set; }
    }
}
