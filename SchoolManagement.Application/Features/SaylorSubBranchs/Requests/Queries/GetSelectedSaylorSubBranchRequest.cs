using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Queries
{
    public class GetSelectedSaylorSubBranchRequest : IRequest<List<SelectedModel>>
    {
    }
}
