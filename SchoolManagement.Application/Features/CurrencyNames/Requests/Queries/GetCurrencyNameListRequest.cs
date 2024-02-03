using MediatR;
using SchoolManagement.Application.DTOs.CurrencyName;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CurrencyNames.Requests.Queries
{
   public class GetCurrencyNameListRequest : IRequest<PagedResult<CurrencyNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 