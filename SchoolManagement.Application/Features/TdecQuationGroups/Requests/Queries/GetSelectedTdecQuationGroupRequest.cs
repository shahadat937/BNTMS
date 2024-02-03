using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Requests.Queries
{
    public class GetSelectedTdecQuationGroupRequest : IRequest<List<SelectedModel>>
    {
    }
}
