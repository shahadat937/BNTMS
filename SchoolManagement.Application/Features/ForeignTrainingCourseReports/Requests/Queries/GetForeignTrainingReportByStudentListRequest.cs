using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ForeignTrainingCourseReport;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignTrainingCourseReports.Requests.Queries
{
   public class GetForeignTrainingReportByStudentListRequest : IRequest<PagedResult<ForeignTrainingCourseReportDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int TraineeId { get; set; }
        public int CourseDurationId { get; set; }

    }
}
