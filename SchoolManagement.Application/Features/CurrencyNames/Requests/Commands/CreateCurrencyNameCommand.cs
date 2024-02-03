using MediatR;
using SchoolManagement.Application.DTOs.CurrencyName;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CurrencyNames.Requests.Commands
{
    public class CreateCurrencyNameCommand : IRequest<BaseCommandResponse>
    {
        public CreateCurrencyNameDto CurrencyNameDto { get; set; }
    }
}
 