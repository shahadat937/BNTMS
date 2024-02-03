using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.CourseTypes.Requests.Queries
{
    public class GetSelectedCourseTypeForMistRequest : IRequest<List<SelectedModel>>
    {
    }
}
