using MediatR;
using SchoolManagement.Application.DTOs.CountryGroup;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CountryGroups.Requests.Queries
{
   public class GetCountryGroupListRequest : IRequest<PagedResult<CountryGroupDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 