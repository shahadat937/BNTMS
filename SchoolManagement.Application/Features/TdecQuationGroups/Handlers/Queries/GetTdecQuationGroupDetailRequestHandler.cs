using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TdecQuationGroup;
using SchoolManagement.Application.Features.TdecQuationGroups.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Handlers.Queries
{
    public class GetTdecQuationGroupDetailRequestHandler : IRequestHandler<GetTdecQuationGroupDetailRequest, TdecQuationGroupDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TdecQuationGroup> _TdecQuationGroupRepository;
        public GetTdecQuationGroupDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TdecQuationGroup> TdecQuationGroupRepository, IMapper mapper)
        {
            _TdecQuationGroupRepository = TdecQuationGroupRepository;
            _mapper = mapper;
        }
        public async Task<TdecQuationGroupDto> Handle(GetTdecQuationGroupDetailRequest request, CancellationToken cancellationToken)
        {
            var TdecQuationGroup = await _TdecQuationGroupRepository.Get(request.TdecQuationGroupId);
            return _mapper.Map<TdecQuationGroupDto>(TdecQuationGroup);
        }
    }
}
