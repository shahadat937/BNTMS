using SchoolManagement.Application.DTOs.BnaPromotionStatus;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Commands
{
    public class CreateBnaPromotionStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaPromotionStatusDto BnaPromotionStatusDto { get; set; }

    }
}
 