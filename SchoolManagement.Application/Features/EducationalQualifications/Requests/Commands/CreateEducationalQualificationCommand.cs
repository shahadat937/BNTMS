using SchoolManagement.Application.DTOs.EducationalQualification;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.EducationalQualifications.Requests.Commands
{
    public class CreateEducationalQualificationCommand : IRequest<BaseCommandResponse>
    {
        public CreateEducationalQualificationDto EducationalQualificationDto { get; set; }

    }
}
