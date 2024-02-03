using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DocumentTypes.Requests.Queries
{
    public class GetSelectedDocumentTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
