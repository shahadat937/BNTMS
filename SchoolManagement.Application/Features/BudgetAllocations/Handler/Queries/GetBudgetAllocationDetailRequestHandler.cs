using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using SchoolManagement.Application.Features.BudgetAllocations.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetAllocations.Handler.Queries
{ 
    public class GetBudgetAllocationDetailRequestHandler : IRequestHandler<GetBudgetAllocationDetailRequest, BudgetAllocationDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<BudgetAllocation> _BudgetAllocationRepository; 
        public GetBudgetAllocationDetailRequestHandler(ISchoolManagementRepository<BudgetAllocation> BudgetAllocationRepository, IMapper mapper)
        {
            _BudgetAllocationRepository = BudgetAllocationRepository; 
            _mapper = mapper;
        }
        public async Task<BudgetAllocationDto> Handle(GetBudgetAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            var BudgetAllocation = await _BudgetAllocationRepository.Get(request.BudgetAllocationId);
            return _mapper.Map<BudgetAllocationDto>(BudgetAllocation);
        }
    }
}
