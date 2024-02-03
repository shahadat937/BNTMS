using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UtofficerCategorys.Requests.Queries
{
    public class GetSelectedUtofficerCategoryRequest : IRequest<List<SelectedModel>> 
    {
    }
}
   