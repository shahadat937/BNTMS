using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.EducationalQualification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.EducationalQualifications.Requests.Queries
{
    public class GetEducationalQualificationDetailRequest : IRequest<EducationalQualificationDto>
    {
        public int EducationalQualificationId { get; set; }
    }
}
