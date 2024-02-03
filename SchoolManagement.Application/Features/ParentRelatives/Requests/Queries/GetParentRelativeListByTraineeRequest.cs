using SchoolManagement.Application.DTOs.ParentRelative;
using MediatR;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.ParentRelatives.Requests.Queries
{
    public class GetParentRelativeListByTraineeRequest : IRequest<List<ParentRelativeDto>>
    {
        public int Traineeid { get; set; }
    }
}
