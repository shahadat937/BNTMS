using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CurrencyNames.Requests.Commands
{
    public class DeleteCurrencyNameCommand : IRequest
    {
        public int CurrencyNameId { get; set; }
    }
}
 