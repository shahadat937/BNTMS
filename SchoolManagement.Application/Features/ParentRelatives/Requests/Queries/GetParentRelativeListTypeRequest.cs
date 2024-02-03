using MediatR;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.ParentRelative;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text; 

namespace SchoolManagement.Application.Features.ParentRelatives.Requests.Queries
{
    public class GetParentRelativeListTypeRequest : IRequest<List<ParentRelativeDto>>
    {
        public int TraineeId { get; set; }  
        public int GroupType { get; set; }  
    }
}
