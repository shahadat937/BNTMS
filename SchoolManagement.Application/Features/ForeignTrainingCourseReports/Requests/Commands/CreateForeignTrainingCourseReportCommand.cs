using MediatR;
using SchoolManagement.Application.DTOs.ForeignTrainingCourseReport;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignTrainingCourseReports.Requests.Commands
{
    public class CreateForeignTrainingCourseReportCommand : IRequest<BaseCommandResponse>
    {
        public CreateForeignTrainingCourseReportDto ForeignTrainingCourseReportDto { get; set; }
    }
}
