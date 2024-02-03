using SchoolManagement.Application.Features.DefenseTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DefenseType;
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


namespace SchoolManagement.Application.Features.DefenseTypes.Handlers.Queries
{
    public class GetDefenseTypeListRequestHandler : IRequestHandler<GetDefenseTypeListRequest, PagedResult<DefenseTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DefenseType> _DefenseTypeRepository;

        private readonly IMapper _mapper;

        public GetDefenseTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DefenseType> DefenseTypeRepository, IMapper mapper)
        {
            _DefenseTypeRepository = DefenseTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DefenseTypeDto>> Handle(GetDefenseTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.DefenseType> UTOfficerCategories = _DefenseTypeRepository.FilterWithInclude(x => (x.DefenseTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.DefenseTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DefenseTypeDtos = _mapper.Map<List<DefenseTypeDto>>(UTOfficerCategories);
            var result = new PagedResult<DefenseTypeDto>(DefenseTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
