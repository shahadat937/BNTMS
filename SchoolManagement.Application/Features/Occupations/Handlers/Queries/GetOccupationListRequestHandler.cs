using SchoolManagement.Application.Features.Occupations.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Occupation;
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


namespace SchoolManagement.Application.Features.Occupations.Handlers.Queries
{
    public class GetOccupationListRequestHandler : IRequestHandler<GetOccupationListRequest, PagedResult<OccupationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Occupation> _OccupationRepository;

        private readonly IMapper _mapper;

        public GetOccupationListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Occupation> OccupationRepository, IMapper mapper)
        {
            _OccupationRepository = OccupationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<OccupationDto>> Handle(GetOccupationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Occupation> Occupations = _OccupationRepository.FilterWithInclude(x => (x.OccupationName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Occupations.Count();
            Occupations = Occupations.OrderByDescending(x => x.OccupationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var OccupationDtos = _mapper.Map<List<OccupationDto>>(Occupations);
            var result = new PagedResult<OccupationDto>(OccupationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
