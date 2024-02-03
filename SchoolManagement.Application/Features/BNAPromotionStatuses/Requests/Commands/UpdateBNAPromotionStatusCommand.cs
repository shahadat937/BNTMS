using SchoolManagement.Application.DTOs.BnaPromotionStatus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Commands
{
    public class UpdateBnaPromotionStatusCommand : IRequest<Unit>
    {
        public BnaPromotionStatusDto BnaPromotionStatusDto { get; set; }

    }
}
 