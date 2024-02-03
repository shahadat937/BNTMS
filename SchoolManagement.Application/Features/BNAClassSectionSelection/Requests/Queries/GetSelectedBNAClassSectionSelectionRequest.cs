using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaClassSectionSelections.Requests.Queries
{
    public class GetSelectedBnaClassSectionSelectionRequest : IRequest<List<SelectedModel>>
    {
    }
}
 