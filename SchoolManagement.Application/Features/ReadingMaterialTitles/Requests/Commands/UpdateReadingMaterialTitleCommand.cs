using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.ReadingMaterialTitle;
using SchoolManagement.Application.DTOs.ReadingMaterialTitles;

namespace SchoolManagement.Application.Features.ReadingMaterialTitles.Requests.Commands
{
    public class UpdateReadingMaterialTitleCommand : IRequest<Unit>
    {
        public ReadingMaterialTitleDto ReadingMaterialTitleDto { get; set; } 

    }
}
 