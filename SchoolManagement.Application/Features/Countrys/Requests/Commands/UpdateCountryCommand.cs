using MediatR;
using SchoolManagement.Application.DTOs.Country;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Countrys.Requests.Commands
{
    public class UpdateCountryCommand : IRequest<Unit>
    {
        public CountryDto CountryDto { get; set; }
    }
}
