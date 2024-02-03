using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Documents.Requests.Queries
{
    public class GetSelectedDocumentRequest : IRequest<List<SelectedModel>>
    {
    }
}
