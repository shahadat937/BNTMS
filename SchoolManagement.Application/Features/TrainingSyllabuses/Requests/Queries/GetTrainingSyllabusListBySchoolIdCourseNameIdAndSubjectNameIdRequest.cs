using MediatR;
using SchoolManagement.Application.DTOs.TrainingSyllabus;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Queries
{
    public class GetTrainingSyllabusListBySchoolIdCourseNameIdAndSubjectNameIdRequest : IRequest<List<TrainingSyllabusDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int BnaSubjectNameId { get; set; }

    }
}

