using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.ReadingMaterialTitle;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.ReadingMaterialTitles;

namespace SchoolManagement.Application.Features.ReadingMaterialTitles.Requests.Queries
{
    public class GetReadingMaterialTitleListRequest : IRequest<PagedResult<ReadingMaterialTitleDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 