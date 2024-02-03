using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetSubjectNameListByFromCourseNameIdAndBranchIdRequest : IRequest<List<BnaSubjectNameDto>>
    {
        public int CourseNameId { get; set; }
        public int BranchId { get; set; } 
    }
}

