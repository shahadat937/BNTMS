using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Boards.Requests.Queries
{
    public class GetSelectedBoardRequest : IRequest<List<SelectedModel>>
    {
    }
}
