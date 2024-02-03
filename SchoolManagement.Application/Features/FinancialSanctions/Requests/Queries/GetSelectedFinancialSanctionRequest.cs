using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.FinancialSanctions.Requests.Queries
{
    public class GetSelectedFinancialSanctionRequest : IRequest<List<SelectedModel>>
    {
    }
}
