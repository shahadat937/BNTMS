using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CountryGroups.Requests.Queries
{
    public class GetSelectedCountryGroupRequest : IRequest<List<SelectedModel>>
    {
    }
}  
  