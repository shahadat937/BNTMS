﻿using SchoolManagement.Application.DTOs.PresentBillet;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.PresentBillets.Requests.Queries
{
    public class GetPresentBilletListRequest : IRequest<PagedResult<PresentBilletDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
