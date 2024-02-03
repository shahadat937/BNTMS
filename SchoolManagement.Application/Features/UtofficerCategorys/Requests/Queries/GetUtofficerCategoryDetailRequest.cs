using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.UtofficerCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UtofficerCategorys.Requests.Queries
{
    public class GetUtofficerCategoryDetailRequest : IRequest<UtofficerCategoryDto>
    {
        public int UtofficerCategoryId { get; set; }
    }
}
