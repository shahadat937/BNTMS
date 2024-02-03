using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeNomination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{ 
    public class GetForeignCourseOtherDocByCourseDurationIdAndCourseNameIdRequest : IRequest<List<TraineeNominationDto>>
    {
        public int CourseDurationId { get; set; } 
        public int CourseNameId { get; set; }
        public int TraineeNominationId { get; set; }
        public int TraineeId { get; set; }
       
    }
} 
 