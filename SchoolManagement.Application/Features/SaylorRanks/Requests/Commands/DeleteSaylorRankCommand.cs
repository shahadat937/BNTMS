using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SaylorRanks.Requests.Commands
{
    public class DeleteSaylorRankCommand : IRequest
    {
        public int SaylorRankId { get; set; }
    }
}
