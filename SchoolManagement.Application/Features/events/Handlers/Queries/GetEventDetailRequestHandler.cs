using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Event;
using SchoolManagement.Application.Features.Events.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Events.Handlers.Queries
{
    public class GetEventDetailRequestHandler : IRequestHandler<GetEventDetailRequest, EventDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Event> _EventRepository;
        public GetEventDetailRequestHandler(ISchoolManagementRepository<Event> EventRepository, IMapper mapper)
        {
            _EventRepository = EventRepository;
            _mapper = mapper;
        }
        public async Task<EventDto> Handle(GetEventDetailRequest request, CancellationToken cancellationToken)
        {
            var Event = await _EventRepository.Get(request.EventId);
            return _mapper.Map<EventDto>(Event);
        }
    }
}
