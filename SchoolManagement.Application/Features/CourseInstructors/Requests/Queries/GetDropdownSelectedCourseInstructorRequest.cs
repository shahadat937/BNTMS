using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetDropdownSelectedCourseInstructorRequest : IRequest<List<SelectedModel>>
    {
        public int BnaSubjectNameId { get; set; }
    }
}
