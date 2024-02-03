using SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup;
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


namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Handlers.Queries
{
    public class GetGuestSpeakerQuationGroupListRequestHandler : IRequestHandler<GetGuestSpeakerQuationGroupListRequest, PagedResult<GuestSpeakerQuationGroupDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerQuationGroup> _GuestSpeakerQuationGroupRepository;

        private readonly IMapper _mapper;

        public GetGuestSpeakerQuationGroupListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerQuationGroup> GuestSpeakerQuationGroupRepository, IMapper mapper)
        {
            _GuestSpeakerQuationGroupRepository = GuestSpeakerQuationGroupRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GuestSpeakerQuationGroupDto>> Handle(GetGuestSpeakerQuationGroupListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.GuestSpeakerQuationGroup> GuestSpeakerQuationGroups = _GuestSpeakerQuationGroupRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText), "BaseSchoolName", "CourseName", "BnaSubjectName", "Trainee", "GuestSpeakerQuestionName");
            var totalCount = GuestSpeakerQuationGroups.Count();
            GuestSpeakerQuationGroups = GuestSpeakerQuationGroups.OrderByDescending(x => x.GuestSpeakerQuationGroupId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var GuestSpeakerQuationGroupDtos = _mapper.Map<List<GuestSpeakerQuationGroupDto>>(GuestSpeakerQuationGroups);
            var result = new PagedResult<GuestSpeakerQuationGroupDto>(GuestSpeakerQuationGroupDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
