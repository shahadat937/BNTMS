using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.SubjectTypes.Requests.Queries
{
    public class GetSelectedKindOfSubjectRequest : IRequest<List<SelectedModel>>
    {
    } 
}
 