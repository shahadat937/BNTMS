using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Countrys.Requests.Commands
{
    public class DeleteCountryCommand : IRequest
    {
        public int CountryId { get; set; }
    }
}
