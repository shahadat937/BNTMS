using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.Election;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Elections.Requests.Queries
{
    public class GetElectionListRequest : IRequest<PagedResult<ElectionDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
