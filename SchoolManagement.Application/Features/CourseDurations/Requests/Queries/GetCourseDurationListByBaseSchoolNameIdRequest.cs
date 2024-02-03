using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseDurationListByBaseSchoolNameIdRequest : IRequest<List<CourseDurationDto>>
    {
        public int BaseSchoolNameId { get; set; }  
    }
}
