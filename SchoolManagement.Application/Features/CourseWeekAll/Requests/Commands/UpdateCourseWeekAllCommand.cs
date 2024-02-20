using MediatR;
using SchoolManagement.Application.DTOs.CourseWeekAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseWeekAll.Requests.Commands
{
    public class UpdateCourseWeekAllCommand:IRequest<Unit>
    {
        public CourseWeekAllDto CourseWeekAllDto { get; set; }
    }
}
