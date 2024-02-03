using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries
{
    public class GetSelectedBnaSubjectNameRequest : IRequest<List<SelectedModel>>
    {
    }
}
 