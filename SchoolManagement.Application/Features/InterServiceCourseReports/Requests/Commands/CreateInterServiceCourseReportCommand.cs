using MediatR;
using SchoolManagement.Application.DTOs.InterServiceCourseReport;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceCourseReports.Requests.Commands
{
    public class CreateInterServiceCourseReportCommand : IRequest<BaseCommandResponse>
    {
        public CreateInterServiceCourseReportDto InterServiceCourseReportDto { get; set; }
    }
}
