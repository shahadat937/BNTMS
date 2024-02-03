using MediatR;
using SchoolManagement.Application.DTOs.InterServiceCourseReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceCourseReports.Requests.Commands
{
    public class UpdateInterServiceCourseReportCommand : IRequest<Unit>
    {
        public InterServiceCourseReportDto InterServiceCourseReportDto { get; set; }
    }
}
