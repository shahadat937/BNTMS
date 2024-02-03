using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseNameBySchoolNameIdRequest : IRequest<List<SelectedModel>>
    {
        //public int CourseNameId { get; set; }
        public int BaseSchoolNameId { get; set; }
    }
} 
