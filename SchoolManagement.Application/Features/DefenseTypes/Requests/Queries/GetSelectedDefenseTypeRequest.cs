using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DefenseTypes.Requests.Queries
{
    public class GetSelectedDefenseTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
