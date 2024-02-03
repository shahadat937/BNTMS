using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseSections.Requests.Queries
{
    public class GetSelectedCourseSectionRequest : IRequest<List<SelectedModel>>
    {
    }
}
