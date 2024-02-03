using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseBudgetAllocation;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Handler.Queries
{ 
    public class GetCourseBudgetAllocationDetailRequestHandler : IRequestHandler<GetCourseBudgetAllocationDetailRequest, CourseBudgetAllocationDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<CourseBudgetAllocation> _CourseBudgetAllocationRepository; 
        public GetCourseBudgetAllocationDetailRequestHandler(ISchoolManagementRepository<CourseBudgetAllocation> CourseBudgetAllocationRepository, IMapper mapper)
        {
            _CourseBudgetAllocationRepository = CourseBudgetAllocationRepository; 
            _mapper = mapper;
        }
        public async Task<CourseBudgetAllocationDto> Handle(GetCourseBudgetAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            var CourseBudgetAllocation = await _CourseBudgetAllocationRepository.Get(request.CourseBudgetAllocationId);
            return _mapper.Map<CourseBudgetAllocationDto>(CourseBudgetAllocation);
        }
    }
}
