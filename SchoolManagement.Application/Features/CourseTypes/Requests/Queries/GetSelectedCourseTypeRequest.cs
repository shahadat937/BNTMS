using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.CourseTypes.Requests.Queries
{
    public class GetSelectedCourseTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
