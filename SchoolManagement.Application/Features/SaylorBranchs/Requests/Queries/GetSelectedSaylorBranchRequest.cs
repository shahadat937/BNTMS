using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.SaylorBranchs.Requests.Queries
{
    public class GetSelectedSaylorBranchRequest : IRequest<List<SelectedModel>>
    {
    }
}
