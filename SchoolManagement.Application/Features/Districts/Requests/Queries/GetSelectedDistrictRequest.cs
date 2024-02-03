using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Districts.Requests.Queries
{
    public class GetSelectedDistrictRequest : IRequest<List<SelectedModel>>
    {
    }
}
