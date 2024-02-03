using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Event;
using SchoolManagement.Application.Features.Events.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Events.Handlers.Queries
{
    public class GetEventListRequestHandler : IRequestHandler<GetEventListRequest, PagedResult<EventDto>>
    {

        private readonly ISchoolManagementRepository<Event> _EventRepository;

        private readonly IMapper _mapper;

        public GetEventListRequestHandler(ISchoolManagementRepository<Event> EventRepository, IMapper mapper)
        {
            _EventRepository = EventRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<EventDto>> Handle(GetEventListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Event> Eventes = _EventRepository.FilterWithInclude(x => (x.EventDetails.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText) && x.BaseSchoolNameId == request.BaseSchoolNameId), "BaseSchoolName", "CourseName");
            var totalCount = Eventes.Count();
            Eventes = Eventes.OrderBy(x => x.Status).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var EventDtos = _mapper.Map<List<EventDto>>(Eventes);
            var result = new PagedResult<EventDto>(EventDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
