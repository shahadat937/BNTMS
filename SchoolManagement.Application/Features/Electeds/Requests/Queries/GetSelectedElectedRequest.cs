using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Electeds.Requests.Queries
{
    public class GetSelectedElectedRequest : IRequest<List<SelectedModel>>
    {
    }
}
