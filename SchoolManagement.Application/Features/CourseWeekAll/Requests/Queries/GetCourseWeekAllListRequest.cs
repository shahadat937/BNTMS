using MediatR;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseWeekAll.Requests.Queries
{
    public class GetCourseWeekAllListRequest
    {
        public int BaseSchoolNameId { get; set; }
    }
}
