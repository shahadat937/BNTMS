using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTasks.Requests.Queries
{
    public class GetSelectedCourseTaskRequest : IRequest<List<SelectedModel>>
    {
    }
}
