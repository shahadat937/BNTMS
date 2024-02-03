using AutoMapper;
using SchoolManagement.Application.DTOs.Gender;
using SchoolManagement.Application.Features.Genders.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.Genders.Handlers.Queries
{
    public class GetGenderListRequestHandler : IRequestHandler<GetGenderListRequest, PagedResult<GenderDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Gender> _GenderRepository;

        private readonly IMapper _mapper;

        public GetGenderListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Gender> GenderRepository, IMapper mapper)
        {
            _GenderRepository = GenderRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GenderDto>> Handle(GetGenderListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Gender> Genders = _GenderRepository.FilterWithInclude(x => (x.GenderName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Genders.Count();
            Genders = Genders.OrderByDescending(x => x.GenderId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var GenderDtos = _mapper.Map<List<GenderDto>>(Genders);
            var result = new PagedResult<GenderDto>(GenderDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
