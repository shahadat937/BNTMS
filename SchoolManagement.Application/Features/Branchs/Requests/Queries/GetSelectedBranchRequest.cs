using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Branchs.Requests.Queries
{
    public class GetSelectedBranchRequest : IRequest<List<SelectedModel>>
    {
    }
}
     