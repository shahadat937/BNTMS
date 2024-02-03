using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.PaymentDetails.Requests.Queries
{
    public class GetSelectedPaymentDetailRequest : IRequest<List<SelectedModel>>
    {
    }
}
    