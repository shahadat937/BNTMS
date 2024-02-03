using MediatR;
using SchoolManagement.Application.DTOs.CountryGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CountryGroups.Requests.Commands
{
    public class UpdateCountryGroupCommand : IRequest<Unit>
    {
        public CountryGroupDto CountryGroupDto { get; set; }
    }
}
 