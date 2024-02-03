using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Genders.Requests.Queries
{
    public class GetSelectedGenderRequest : IRequest<List<SelectedModel>>
    {
    }
}
