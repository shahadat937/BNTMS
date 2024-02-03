﻿using SchoolManagement.Application.Features.NewAtempts.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NewAtempt;
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
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.NewAtempts.Handlers.Queries
{
    public class GetNewAtemptListRequestHandler : IRequestHandler<GetNewAtemptListRequest, PagedResult<NewAtemptDto>>
    {

        private readonly ISchoolManagementRepository<NewAtempt> _NewAtemptRepository;

        private readonly IMapper _mapper;

        public GetNewAtemptListRequestHandler(ISchoolManagementRepository<NewAtempt> NewAtemptRepository, IMapper mapper)
        {
            _NewAtemptRepository = NewAtemptRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<NewAtemptDto>> Handle(GetNewAtemptListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<NewAtempt> NewAtempts = _NewAtemptRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = NewAtempts.Count();
            NewAtempts = NewAtempts.OrderByDescending(x => x.NewAtemptId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var NewAtemptDtos = _mapper.Map<List<NewAtemptDto>>(NewAtempts);
            var result = new PagedResult<NewAtemptDto>(NewAtemptDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
