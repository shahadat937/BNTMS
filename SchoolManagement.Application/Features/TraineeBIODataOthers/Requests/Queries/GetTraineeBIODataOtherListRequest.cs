using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeBioDataOther;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Queries
{
    public class GetTraineeBioDataOtherListRequest : IRequest<PagedResult<TraineeBioDataOtherDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
