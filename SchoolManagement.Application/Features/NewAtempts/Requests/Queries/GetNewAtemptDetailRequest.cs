using MediatR;
using SchoolManagement.Application.DTOs.NewAtempt;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NewAtempts.Requests.Queries
{
    public class GetNewAtemptDetailRequest : IRequest<NewAtemptDto>
    {
        public int NewAtemptId { get; set; }
    }
}
 