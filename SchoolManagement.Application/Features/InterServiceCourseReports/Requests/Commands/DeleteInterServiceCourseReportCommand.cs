using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceCourseReports.Requests.Commands
{
    public class DeleteInterServiceCourseReportCommand : IRequest
    {
        public int InterServiceCourseReportid { get; set; }
    }
}
