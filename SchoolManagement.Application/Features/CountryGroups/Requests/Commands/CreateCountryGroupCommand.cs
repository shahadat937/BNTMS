using MediatR;
using SchoolManagement.Application.DTOs.CountryGroup;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CountryGroups.Requests.Commands
{
    public class CreateCountryGroupCommand : IRequest<BaseCommandResponse>
    {
        public CreateCountryGroupDto CountryGroupDto { get; set; }
    }
}
 