using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.PaymentDetails.Requests.Commands
{
    public class DeletePaymentDetailCommand : IRequest
    {  
        public int Id { get; set; }
    }
}
