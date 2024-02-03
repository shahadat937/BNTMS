using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ReadingMaterialTitles.Requests.Queries
{
    public class GetSelectedReadingMaterialTitleRequest : IRequest<List<SelectedModel>>
    {
    }
}
 