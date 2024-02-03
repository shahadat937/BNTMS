using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignTrainingCourseReports.Requests.Commands
{
    public class DeleteForeignTrainingCourseReportCommand : IRequest
    {
        public int ForeignTrainingCourseReportid { get; set; }
    }
}
