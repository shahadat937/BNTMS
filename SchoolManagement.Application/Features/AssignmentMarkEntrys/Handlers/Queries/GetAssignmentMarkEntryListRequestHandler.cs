using SchoolManagement.Application.Features.AssignmentMarkEntrys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
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
using SchoolManagement.Application.DTOs.AssignmentMarkEntry;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AssignmentMarkEntrys.Handlers.Queries
{
    public class GetAssignmentMarkEntryListRequestHandler : IRequestHandler<GetAssignmentMarkEntryListRequest, PagedResult<AssignmentMarkEntryDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.AssignmentMarkEntry> _AssignmentMarkEntryRepository;

        private readonly IMapper _mapper;

        public GetAssignmentMarkEntryListRequestHandler(ISchoolManagementRepository<AssignmentMarkEntry> AssignmentMarkEntryRepository, IMapper mapper)
        {
            _AssignmentMarkEntryRepository = AssignmentMarkEntryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AssignmentMarkEntryDto>> Handle(GetAssignmentMarkEntryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<AssignmentMarkEntry> AssignmentMarkEntrys = _AssignmentMarkEntryRepository.FilterWithInclude(x => ( String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = AssignmentMarkEntrys.Count();
            AssignmentMarkEntrys = AssignmentMarkEntrys.OrderByDescending(x => x.AssignmentMarkEntryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AssignmentMarkEntryDtos = _mapper.Map<List<AssignmentMarkEntryDto>>(AssignmentMarkEntrys);
            var result = new PagedResult<AssignmentMarkEntryDto>(AssignmentMarkEntryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
