using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Castes.Requests.Queries
{
    public class GetSelectedCasteRequest : IRequest<List<SelectedModel>>
    {
    }
}
