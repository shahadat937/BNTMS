using MediatR;
using SchoolManagement.Application.DTOs.ForeignTrainingCourseReport;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignTrainingCourseReports.Requests.Queries
{
    public class GetForeignTrainingCourseReportDetailRequest : IRequest<ForeignTrainingCourseReportDto>
    {
        public int ForeignTrainingCourseReportid { get; set; }
    }
}
