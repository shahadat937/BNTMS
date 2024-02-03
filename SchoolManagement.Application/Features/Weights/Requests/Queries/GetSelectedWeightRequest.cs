using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Weights.Requests.Queries
{
    public class GetSelectedWeightRequest : IRequest<List<SelectedModel>>
    {
    }
}
    