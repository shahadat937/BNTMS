using MediatR;
using SchoolManagement.Application.DTOs.InterServiceCourseReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceCourseReports.Requests.Queries
{
    public class GetInterServiceCourseReportDetailRequest : IRequest<InterServiceCourseReportDto>
    {
        public int InterServiceCourseReportid { get; set; }
    }
}
