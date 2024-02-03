using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.EducationalInstitutions.Requests.Commands
{
    public class DeleteEducationalInstitutionCommand : IRequest  
    {  
        public int Id { get; set; }
    }
}
