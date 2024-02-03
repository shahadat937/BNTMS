using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.Thana;
using SchoolManagement.Application.Features.Thanas.Requests;
using SchoolManagement.Application.Features.Thanas.Requests.Queries;
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

namespace SchoolManagement.Application.Features.Thanas.Handlers.Queries
{
    public class GetThanaListRequestHandler : IRequestHandler<GetThanaListRequest, PagedResult<ThanaDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Thana> _ThanaRepository;

        private readonly IMapper _mapper;

        public GetThanaListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Thana> ThanaRepository, IMapper mapper)
        {
            _ThanaRepository = ThanaRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ThanaDto>> Handle(GetThanaListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Thana> Thanas = _ThanaRepository.FilterWithInclude(x => x.ThanaId != 504 && (x.ThanaName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "District");
            var totalCount = Thanas.Count();
            Thanas = Thanas.OrderByDescending(x => x.ThanaId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ThanaDtos = _mapper.Map<List<ThanaDto>>(Thanas);
            var result = new PagedResult<ThanaDto>(ThanaDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
