using MediatR;
using SchoolManagement.Application.DTOs.SaylorBranch;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SaylorBranchs.Requests.Queries
{
    public class GetSaylorBranchDetailRequest : IRequest<SaylorBranchDto>
    {
        public int SaylorBranchId { get; set; }
    }
}
