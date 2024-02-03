using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Branchs.Handler.Queries
{ 
    public class GetBranchDetailRequestHandler : IRequestHandler<GetBranchDetailRequest, BranchDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<Branch> _branchRepository; 
        public GetBranchDetailRequestHandler(ISchoolManagementRepository<Branch> branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository; 
            _mapper = mapper;
        }
        public async Task<BranchDto> Handle(GetBranchDetailRequest request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.Get(request.Id);
            return _mapper.Map<BranchDto>(branch);
        }
    }
}
