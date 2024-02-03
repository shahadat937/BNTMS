using SchoolManagement.Application.Features.ForceTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForceType;
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


namespace SchoolManagement.Application.Features.ForceTypes.Handlers.Queries
{
    public class GetForceTypeListRequestHandler : IRequestHandler<GetForceTypeListRequest, PagedResult<ForceTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ForceType> _ForceTypeRepository;

        private readonly IMapper _mapper;

        public GetForceTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ForceType> ForceTypeRepository, IMapper mapper)
        {
            _ForceTypeRepository = ForceTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ForceTypeDto>> Handle(GetForceTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ForceType> UTOfficerCategories = _ForceTypeRepository.FilterWithInclude(x => (x.ForceTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ForceTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ForceTypeDtos = _mapper.Map<List<ForceTypeDto>>(UTOfficerCategories);
            var result = new PagedResult<ForceTypeDto>(ForceTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
