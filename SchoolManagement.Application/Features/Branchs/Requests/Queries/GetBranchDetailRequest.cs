using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Branchs.Requests.Queries
{
    public class GetBranchDetailRequest : IRequest<BranchDto>
    {
        public int Id { get; set; }
    }
}
