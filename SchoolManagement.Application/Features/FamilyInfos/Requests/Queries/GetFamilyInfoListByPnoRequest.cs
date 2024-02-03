using MediatR;
using SchoolManagement.Application.DTOs.FamilyInfo;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FamilyInfos.Requests.Queries
{
    public class GetFamilyInfoListByPnoRequest : IRequest<List<FamilyInfoDto>>
    {
        public int TraineeId { get; set; }
       
    }
}

