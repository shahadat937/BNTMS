using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.UtofficerCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.UtofficerCategorys.Requests.Queries
{
    public class GetUtofficerCategoryListRequest : IRequest<PagedResult<UtofficerCategoryDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
