using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaExamInstructorAssign;
using SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaExamInstructorAssigns.Handlers.Queries
{
    public class GetBnaExamInstructorAssignDetailRequestHandler : IRequestHandler<GetBnaExamInstructorAssignDetailRequest, BnaExamInstructorAssignDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaExamInstructorAssign> _BnaExamInstructorAssignRepository;
        public GetBnaExamInstructorAssignDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaExamInstructorAssign> BnaExamInstructorAssignRepository, IMapper mapper)
        {
            _BnaExamInstructorAssignRepository = BnaExamInstructorAssignRepository;
            _mapper = mapper;
        }
        public async Task<BnaExamInstructorAssignDto> Handle(GetBnaExamInstructorAssignDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaExamInstructorAssign = await _BnaExamInstructorAssignRepository.Get(request.BnaExamInstructorAssignId);
            return _mapper.Map<BnaExamInstructorAssignDto>(BnaExamInstructorAssign);
        }
    }
}
