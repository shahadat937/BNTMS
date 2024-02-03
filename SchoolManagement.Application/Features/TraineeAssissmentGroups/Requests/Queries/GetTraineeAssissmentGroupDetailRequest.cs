using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeAssissmentGroup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Queries
{
    public class GetTraineeAssissmentGroupDetailRequest : IRequest<TraineeAssissmentGroupDto>
    {
        public int TraineeAssissmentGroupId { get; set; }
    }
}
