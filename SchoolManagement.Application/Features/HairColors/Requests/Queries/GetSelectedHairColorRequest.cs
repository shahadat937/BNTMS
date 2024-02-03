using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.HairColors.Requests.Queries
{
    public class GetSelectedHairColorRequest : IRequest<List<SelectedModel>>
    {
    }
}
