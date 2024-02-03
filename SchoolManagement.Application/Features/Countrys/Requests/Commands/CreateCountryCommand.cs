using MediatR;
using SchoolManagement.Application.DTOs.Country;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Countrys.Requests.Commands
{
    public class CreateCountryCommand : IRequest<BaseCommandResponse>
    {
        public CreateCountryDto CountryDto { get; set; }
    }
}
