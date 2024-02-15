using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolManagement.Application.DTOs.CourseWeekAll;

namespace SchoolManagement.Application.Features.CourseWeekAll.Requests.Commands
{
    public class CreateCourseWeekAllCommand : IRequest<BaseCommandResponse>
    {
        public createCourseWeekAllDto CourseWeekAllDto { get; set; }
    }
}
