using MediatR;
using SchoolManagement.Application.DTOs.TrainingSyllabus;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Queries
{
   public class GetTrainingSyllabusListRequest : IRequest<PagedResult<TrainingSyllabusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
