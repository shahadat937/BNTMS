using AutoMapper;
using SchoolManagement.Application.DTOs.Event;
using SchoolManagement.Application.Features.Events.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Events.Handlers.Queries   
{
    public class GetSelectedEventBySchoolRequestHandler : IRequestHandler<GetSelectedEventBySchoolRequest, List<EventDto>>
    {

        private readonly ISchoolManagementRepository<Event> _EventRepository;

        private readonly IMapper _mapper;

        public GetSelectedEventBySchoolRequestHandler(ISchoolManagementRepository<Event> EventRepository, IMapper mapper)
        {
            _EventRepository = EventRepository;
            _mapper = mapper;
        }

        public async Task<List<EventDto>> Handle(GetSelectedEventBySchoolRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Event> Events = _EventRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId, "CourseName", "CourseDuration").OrderBy(x => x.Status);

            var EventDtos = _mapper.Map<List<EventDto>>(Events);

            return EventDtos;
        }
    }
}
