using MediatR;
using SchoolManagement.Application.DTOs.CurrencyName;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CurrencyNames.Requests.Commands
{
    public class UpdateCurrencyNameCommand : IRequest<Unit>
    {
        public CurrencyNameDto CurrencyNameDto { get; set; }
    }
}
 