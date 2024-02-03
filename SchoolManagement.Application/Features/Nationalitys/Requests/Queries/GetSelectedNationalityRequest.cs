using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Nationalitys.Requests.Queries
{
    public class GetSelectedNationalityRequest : IRequest<List<SelectedModel>>
    {
    }
}
