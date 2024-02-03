using MediatR;
using SchoolManagement.Application.DTOs.TraineeBioDataOther;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Queries
{
    public class GetTraineeBioDataOtherListByTraineeRequest : IRequest<List<TraineeBioDataOtherDto>>
    {
        public int TraineeId { get; set; }
    }
}
