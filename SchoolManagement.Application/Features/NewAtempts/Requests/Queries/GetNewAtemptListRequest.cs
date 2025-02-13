﻿using MediatR;
using SchoolManagement.Application.DTOs.NewAtempt;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NewAtempts.Requests.Queries
{
   public class GetNewAtemptListRequest : IRequest<PagedResult<NewAtemptDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 