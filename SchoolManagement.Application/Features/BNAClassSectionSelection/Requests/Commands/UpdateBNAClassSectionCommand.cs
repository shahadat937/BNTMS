using MediatR;
using SchoolManagement.Application.DTOs.BnaClassSectionSelection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaClassSections.Requests.Commands
{
    public class UpdateBnaClassSectionCommand : IRequest<Unit>
    {
        public BnaClassSectionSelectionDto BnaClassSectionDto { get; set; } 
    }
}
