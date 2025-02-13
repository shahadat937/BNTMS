﻿using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetBNASubjectNameListByCourseNameIdRequest : IRequest<List<BnaSubjectNameDto>>
    {  
        
        public int CourseNameId { get; set; }
    } 
}
 
 