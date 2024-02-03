using MediatR;
using SchoolManagement.Application.DTOs.Country;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Countrys.Requests.Queries
{
    public class GetCountryDetailRequest : IRequest<CountryDto>
    {
        public int CountryId { get; set; }
    }
}
