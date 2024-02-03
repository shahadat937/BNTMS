using MediatR;
using SchoolManagement.Application.DTOs.Country;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Countrys.Requests.Queries
{
   public class GetCountryListRequest : IRequest<PagedResult<CountryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
