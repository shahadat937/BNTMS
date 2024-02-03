using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.Election;
using SchoolManagement.Application.Features.Elections.Requests;
using SchoolManagement.Application.Features.Elections.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.Elections.Handlers.Queries
{
    public class GetElectionListRequestHandler : IRequestHandler<GetElectionListRequest, PagedResult<ElectionDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Election> _ElectionRepository;

        private readonly IMapper _mapper;

        public GetElectionListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Election> ElectionRepository, IMapper mapper)
        {
            _ElectionRepository = ElectionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ElectionDto>> Handle(GetElectionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Election> Elections = _ElectionRepository.FilterWithInclude(x => (x.InstituteName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "Elected");
            var totalCount = Elections.Count();
            Elections = Elections.OrderByDescending(x => x.ElectionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ElectionDtos = _mapper.Map<List<ElectionDto>>(Elections);
            var result = new PagedResult<ElectionDto>(ElectionDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
