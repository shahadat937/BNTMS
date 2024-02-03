using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseModules.Requests.Queries
{
    public class GetSelectedCourseModuleRequest : IRequest<List<SelectedModel>>
    {
    }
}
