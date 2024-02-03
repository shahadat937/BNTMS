using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GuestSpeakerActionStatus;
using SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Handlers.Queries
{
    public class GetGuestSpeakerActionStatusDetailRequestHandler : IRequestHandler<GetGuestSpeakerActionStatusDetailRequest, GuestSpeakerActionStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerActionStatus> _GuestSpeakerActionStatusRepository;
        public GetGuestSpeakerActionStatusDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerActionStatus> GuestSpeakerActionStatusRepository, IMapper mapper)
        {
            _GuestSpeakerActionStatusRepository = GuestSpeakerActionStatusRepository;
            _mapper = mapper;
        }
        public async Task<GuestSpeakerActionStatusDto> Handle(GetGuestSpeakerActionStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var GuestSpeakerActionStatus = await _GuestSpeakerActionStatusRepository.Get(request.GuestSpeakerActionStatusId);
            return _mapper.Map<GuestSpeakerActionStatusDto>(GuestSpeakerActionStatus);
        }
    }
}
