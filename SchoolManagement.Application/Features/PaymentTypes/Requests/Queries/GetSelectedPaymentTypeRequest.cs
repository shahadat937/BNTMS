using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.PaymentTypes.Requests.Queries
{
    public class GetSelectedPaymentTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
