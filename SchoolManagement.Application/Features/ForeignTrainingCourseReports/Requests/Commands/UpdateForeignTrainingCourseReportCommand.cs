using MediatR;
using SchoolManagement.Application.DTOs.ForeignTrainingCourseReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignTrainingCourseReports.Requests.Commands
{
    public class UpdateForeignTrainingCourseReportCommand : IRequest<Unit>
    {
        public ForeignTrainingCourseReportDto ForeignTrainingCourseReportDto { get; set; }
    }
}
