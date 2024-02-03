using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.EducationalQualification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.EducationalQualifications.Requests.Queries
{
    public class GetEducationalQualificationListRequest : IRequest<PagedResult<EducationalQualificationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
