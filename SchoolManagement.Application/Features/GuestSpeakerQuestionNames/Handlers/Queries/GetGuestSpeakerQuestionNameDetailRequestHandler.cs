using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName;
using SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Handlers.Queries
{
    public class GetGuestSpeakerQuestionNameDetailRequestHandler : IRequestHandler<GetGuestSpeakerQuestionNameDetailRequest, GuestSpeakerQuestionNameDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerQuestionName> _GuestSpeakerQuestionNameRepository;
        public GetGuestSpeakerQuestionNameDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerQuestionName> GuestSpeakerQuestionNameRepository, IMapper mapper)
        {
            _GuestSpeakerQuestionNameRepository = GuestSpeakerQuestionNameRepository;
            _mapper = mapper;
        }
        public async Task<GuestSpeakerQuestionNameDto> Handle(GetGuestSpeakerQuestionNameDetailRequest request, CancellationToken cancellationToken)
        {
            var GuestSpeakerQuestionName = await _GuestSpeakerQuestionNameRepository.Get(request.GuestSpeakerQuestionNameId);
            return _mapper.Map<GuestSpeakerQuestionNameDto>(GuestSpeakerQuestionName);
        }
    }
}
