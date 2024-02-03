using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FamilyInfos.Requests.Queries
{
    public class GetSelectedFamilyInfoRequest : IRequest<List<SelectedModel>>
    {
    }
}  
  