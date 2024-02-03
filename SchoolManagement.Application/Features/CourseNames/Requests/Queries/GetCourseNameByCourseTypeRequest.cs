using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.CourseNames.Requests.Queries
{
    public class GetCourseNameByCourseTypeRequest : IRequest<List<SelectedModel>>
    {
        public int CourseTypeId { get; set; }
    } 
}
 