using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ResultStatuses.Requests.Queries
{
    public class GetSelectedResultStatusRequest : IRequest<List<SelectedModel>>
    {
    }
}
