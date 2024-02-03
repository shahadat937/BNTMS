using MediatR;
using SchoolManagement.Application.DTOs.BnaClassSectionSelection;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaClassSections.Requests.Commands
{
    public class CreateBnaClassSectionCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaClassSectionSelectionDto BnaClassSectionDto { get; set; } 

    }
}
