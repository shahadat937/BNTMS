using MediatR;
using SchoolManagement.Application.DTOs.ColorOfEye;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ColorOfEyes.Requests.Queries
{
    public class GetColorOfEyeListRequest : IRequest<PagedResult<ColorOfEyeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
