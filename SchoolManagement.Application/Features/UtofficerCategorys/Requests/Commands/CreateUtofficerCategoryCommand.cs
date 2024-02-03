using SchoolManagement.Application.DTOs.UtofficerCategory;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UtofficerCategorys.Requests.Commands
{
    public class CreateUtofficerCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateUtofficerCategoryDto UtofficerCategoryDto { get; set; }

    }
}
