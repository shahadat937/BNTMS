using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.PaymentTypes.Requests.Commands
{
    public class DeletePaymentTypeCommand : IRequest
    {
        public int PaymentTypeId { get; set; }
    }
}
 