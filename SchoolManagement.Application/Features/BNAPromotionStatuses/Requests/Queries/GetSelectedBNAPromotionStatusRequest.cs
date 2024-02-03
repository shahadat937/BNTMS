using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Queries
{
    public class GetSelectedBnaPromotionStatusRequest : IRequest<List<SelectedModel>> 
    {
    }
}
       