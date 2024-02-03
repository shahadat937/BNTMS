using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.FamilyInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.FamilyInfos.Requests.Queries
{
    public class GetFamilyInfoListTraineeIdRequest : IRequest<List<FamilyInfoDto>>
    {
        //public QueryParams QueryParams { get; set; }
        public int TraineeId { get; set; }
    } 
}
