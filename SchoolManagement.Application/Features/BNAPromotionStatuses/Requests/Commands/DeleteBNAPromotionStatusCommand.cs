using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Commands
{
    public class DeleteBnaPromotionStatusCommand : IRequest
    {
        public int BnaPromotionStatusId { get; set; }
    }
}
 