using SchoolManagement.Application.Features.Nationalitys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Nationality;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.Nationalitys.Handlers.Queries
{
    public class GetNationalityListRequestHandler : IRequestHandler<GetNationalityListRequest, PagedResult<NationalityDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Nationality> _NationalityRepository;

        private readonly IMapper _mapper;

        public GetNationalityListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Nationality> NationalityRepository, IMapper mapper)
        {
            _NationalityRepository = NationalityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<NationalityDto>> Handle(GetNationalityListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Nationality> UTOfficerCategories = _NationalityRepository.FilterWithInclude(x => x.NationalityId != 25 && (x.NationalityName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.NationalityId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var NationalityDtos = _mapper.Map<List<NationalityDto>>(UTOfficerCategories);
            var result = new PagedResult<NationalityDto>(NationalityDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
