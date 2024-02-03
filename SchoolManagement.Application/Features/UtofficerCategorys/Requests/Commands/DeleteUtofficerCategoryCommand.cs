using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UtofficerCategorys.Requests.Commands
{
    public class DeleteUtofficerCategoryCommand : IRequest
    {
        public int UtofficerCategoryId { get; set; }
    }
}
