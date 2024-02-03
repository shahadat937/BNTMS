using MediatR;
using SchoolManagement.Application.DTOs.TrainingObjective;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingObjectives.Requests.Queries
{
    public class GetTrainingObjectiveListBySchoolIdCourseNameIdAndSubjectNameIdRequest : IRequest<List<TrainingObjectiveDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int BnaSubjectNameId { get; set; }

    }
}

