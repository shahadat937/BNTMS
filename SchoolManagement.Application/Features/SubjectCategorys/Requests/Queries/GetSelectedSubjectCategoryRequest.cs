using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SubjectCategorys.Requests.Queries   
{
    public class GetSelectedSubjectCategoryRequest : IRequest<List<SelectedModel>> 
    {
    }
} 
 