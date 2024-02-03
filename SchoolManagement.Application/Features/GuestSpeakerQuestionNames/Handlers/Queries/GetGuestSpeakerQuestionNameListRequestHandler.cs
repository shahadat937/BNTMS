using SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName;
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


namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Handlers.Queries
{
    public class GetGuestSpeakerQuestionNameListRequestHandler : IRequestHandler<GetGuestSpeakerQuestionNameListRequest, PagedResult<GuestSpeakerQuestionNameDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerQuestionName> _GuestSpeakerQuestionNameRepository;

        private readonly IMapper _mapper;

        public GetGuestSpeakerQuestionNameListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerQuestionName> GuestSpeakerQuestionNameRepository, IMapper mapper)
        {
            _GuestSpeakerQuestionNameRepository = GuestSpeakerQuestionNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GuestSpeakerQuestionNameDto>> Handle(GetGuestSpeakerQuestionNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.GuestSpeakerQuestionName> GuestSpeakerQuestionNames = _GuestSpeakerQuestionNameRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = GuestSpeakerQuestionNames.Count();
            GuestSpeakerQuestionNames = GuestSpeakerQuestionNames.OrderByDescending(x => x.GuestSpeakerQuestionNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var GuestSpeakerQuestionNameDtos = _mapper.Map<List<GuestSpeakerQuestionNameDto>>(GuestSpeakerQuestionNames);
            var result = new PagedResult<GuestSpeakerQuestionNameDto>(GuestSpeakerQuestionNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
