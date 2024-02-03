using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CoursePlans.Requests.Queries
{
    public class GetSelectedCoursePlanRequest : IRequest<List<SelectedModel>>
    {
    }
}
