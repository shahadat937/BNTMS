using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Requests.Queries
{
    public class GetTraineeBioDataGeneralInfoListForByTraineeStatusRequest : IRequest<PagedResult<TraineeBioDataGeneralInfoDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int TraineeStatusId { get; set; }
    }
}
