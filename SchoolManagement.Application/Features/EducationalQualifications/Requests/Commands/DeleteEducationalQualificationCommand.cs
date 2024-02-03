using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.EducationalQualifications.Requests.Commands
{
    public class DeleteEducationalQualificationCommand : IRequest
    {
        public int EducationalQualificationId { get; set; }
    }
}
