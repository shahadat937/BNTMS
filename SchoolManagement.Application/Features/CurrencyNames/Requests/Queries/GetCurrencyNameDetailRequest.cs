using MediatR;
using SchoolManagement.Application.DTOs.CurrencyName;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CurrencyNames.Requests.Queries
{
    public class GetCurrencyNameDetailRequest : IRequest<CurrencyNameDto>
    {
        public int CurrencyNameId { get; set; }
    }
}
 