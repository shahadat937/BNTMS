using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Languages.Requests.Queries
{
    public class GetSelectedLanguageRequest : IRequest<List<SelectedModel>>
    {
    }
}
 