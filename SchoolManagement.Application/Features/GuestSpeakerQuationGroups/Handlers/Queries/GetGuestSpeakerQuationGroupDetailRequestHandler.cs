using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup;
using SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Handlers.Queries
{
    public class GetGuestSpeakerQuationGroupDetailRequestHandler : IRequestHandler<GetGuestSpeakerQuationGroupDetailRequest, GuestSpeakerQuationGroupDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerQuationGroup> _GuestSpeakerQuationGroupRepository;
        public GetGuestSpeakerQuationGroupDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerQuationGroup> GuestSpeakerQuationGroupRepository, IMapper mapper)
        {
            _GuestSpeakerQuationGroupRepository = GuestSpeakerQuationGroupRepository;
            _mapper = mapper;
        }
        public async Task<GuestSpeakerQuationGroupDto> Handle(GetGuestSpeakerQuationGroupDetailRequest request, CancellationToken cancellationToken)
        {
            var GuestSpeakerQuationGroup = await _GuestSpeakerQuationGroupRepository.Get(request.GuestSpeakerQuationGroupId);
            return _mapper.Map<GuestSpeakerQuationGroupDto>(GuestSpeakerQuationGroup);
        }
    }
}
