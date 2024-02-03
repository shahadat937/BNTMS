using MediatR;
using SchoolManagement.Application.DTOs.CountryGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CountryGroups.Requests.Queries
{
    public class GetCountryGroupDetailRequest : IRequest<CountryGroupDto>
    {
        public int CountryGroupId { get; set; }
    }
}
 