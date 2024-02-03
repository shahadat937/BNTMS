using MediatR;
using SchoolManagement.Application.DTOs.PaymentType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.PaymentTypes.Requests.Commands
{
    public class CreatePaymentTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreatePaymentTypeDto PaymentTypeDto { get; set; }
    }
}
