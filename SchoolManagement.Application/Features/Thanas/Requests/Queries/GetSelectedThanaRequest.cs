using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Thanas.Requests.Queries
{
    public class GetSelectedThanaRequest : IRequest<List<SelectedModel>>
    {
    }
}
