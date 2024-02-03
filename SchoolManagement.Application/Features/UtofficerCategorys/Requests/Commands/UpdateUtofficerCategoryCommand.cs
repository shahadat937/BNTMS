using SchoolManagement.Application.DTOs.UtofficerCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UtofficerCategorys.Requests.Commands
{
    public class UpdateUtofficerCategoryCommand : IRequest<Unit>
    {
        public UtofficerCategoryDto UtofficerCategoryDto { get; set; }

    }
}
