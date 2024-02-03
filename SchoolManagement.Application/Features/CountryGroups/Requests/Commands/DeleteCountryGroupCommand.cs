using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CountryGroups.Requests.Commands
{
    public class DeleteCountryGroupCommand : IRequest
    {
        public int CountryGroupId { get; set; }
    }
}
 