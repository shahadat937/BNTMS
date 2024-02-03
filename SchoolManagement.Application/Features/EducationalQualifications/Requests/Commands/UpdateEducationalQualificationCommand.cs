using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.EducationalQualification;

namespace SchoolManagement.Application.Features.EducationalQualifications.Requests.Commands
{
    public class UpdateEducationalQualificationCommand : IRequest<Unit>
    {
        public EducationalQualificationDto EducationalQualificationDto { get; set; } 

    }
}
