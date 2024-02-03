using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Countrys.Requests.Queries
{
    public class GetSelectedCountryRequest : IRequest<List<SelectedModel>>
    {
    }
}
