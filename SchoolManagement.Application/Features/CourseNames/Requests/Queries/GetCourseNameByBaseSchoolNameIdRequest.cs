using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic; 
using System.Text; 

namespace SchoolManagement.Application.Features.CourseNames.Requests.Queries
{
    public class GetCourseNameByBaseSchoolNameIdRequest : IRequest<List<SelectedModel>>
    {
        public int BaseSchoolNameId { get; set; }  
    }
}
 
