using SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GuestSpeakerActionStatus;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;


namespace SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Handlers.Queries
{
    public class GetGuestSpeakerActionStatusListRequestHandler : IRequestHandler<GetGuestSpeakerActionStatusListRequest, PagedResult<GuestSpeakerActionStatusDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerActionStatus> _GuestSpeakerActionStatusRepository;

        private readonly IMapper _mapper;

        public GetGuestSpeakerActionStatusListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerActionStatus> GuestSpeakerActionStatusRepository, IMapper mapper)
        {
            _GuestSpeakerActionStatusRepository = GuestSpeakerActionStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GuestSpeakerActionStatusDto>> Handle(GetGuestSpeakerActionStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.GuestSpeakerActionStatus> GuestSpeakerActionStatuss = _GuestSpeakerActionStatusRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = GuestSpeakerActionStatuss.Count();
            GuestSpeakerActionStatuss = GuestSpeakerActionStatuss.OrderByDescending(x => x.GuestSpeakerActionStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var GuestSpeakerActionStatusDtos = _mapper.Map<List<GuestSpeakerActionStatusDto>>(GuestSpeakerActionStatuss);
            var result = new PagedResult<GuestSpeakerActionStatusDto>(GuestSpeakerActionStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
