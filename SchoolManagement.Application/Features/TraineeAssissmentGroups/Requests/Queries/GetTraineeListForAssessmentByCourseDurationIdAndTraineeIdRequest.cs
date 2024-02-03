using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeAssissmentGroup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Queries
{
    public class GetTraineeListForAssessmentByCourseDurationIdAndTraineeIdRequest : IRequest<List<TraineeAssissmentGroupDto>>
    {
        public int CourseDurationId { get; set; }
        public int TraineeId { get; set; }
        public int TraineeAssissmentCreateId { get; set; }
    }
}
