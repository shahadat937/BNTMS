using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.CourseNames.Requests.Queries
{
    public class GetAutoCompleteCourseNameByTypeRequest : IRequest<List<SelectedModel>>
    {
        public int CourseTypeId { get; set; }
        public string CourseName { get; set; }
    }
}
 