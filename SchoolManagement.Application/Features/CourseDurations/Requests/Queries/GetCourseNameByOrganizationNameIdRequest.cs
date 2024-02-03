using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseNameByOrganizationNameIdRequest : IRequest<List<SelectedModel>>
    {
        public int OrganizationNameId { get; set; }    
    }
} 
