using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Queries
{
    public class GetSelectedCourseBudgetAllocationRequest : IRequest<List<SelectedModel>>
    {
    }
}
     