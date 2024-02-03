using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecActionStatuses.Requests.Queries
{
    public class GetSelectedTdecActionStatusRequest : IRequest<List<SelectedModel>>
    {
    }
}
