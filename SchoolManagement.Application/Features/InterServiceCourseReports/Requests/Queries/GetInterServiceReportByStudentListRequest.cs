using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.InterServiceCourseReport;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceCourseReports.Requests.Queries
{
   public class GetInterServiceReportByStudentListRequest : IRequest<PagedResult<InterServiceCourseReportDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int TraineeId { get; set; }
        public int CourseDurationId { get; set; }

    }
}
