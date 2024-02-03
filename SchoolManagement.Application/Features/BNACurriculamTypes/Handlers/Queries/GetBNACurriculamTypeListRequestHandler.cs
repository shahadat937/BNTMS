using SchoolManagement.Application.Features.BnaCurriculamTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaCurriculamType;
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

namespace SchoolManagement.Application.Features.BnaCurriculamTypes.Handlers.Queries
{
    public class GetBnaCurriculamTypeListRequestHandler : IRequestHandler<GetBnaCurriculamTypeListRequest, PagedResult<BnaCurriculamTypeDto>>
    {

        private readonly ISchoolManagementRepository<BnaCurriculumType> _BnaCurriculamTypeRepository;

        private readonly IMapper _mapper;

        public GetBnaCurriculamTypeListRequestHandler(ISchoolManagementRepository<BnaCurriculumType> BnaCurriculamTypeRepository, IMapper mapper)
        {
            _BnaCurriculamTypeRepository = BnaCurriculamTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaCurriculamTypeDto>> Handle(GetBnaCurriculamTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BnaCurriculumType> UTOfficerCategories = _BnaCurriculamTypeRepository.FilterWithInclude(x => (x.CurriculumType.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.BnaCurriculumTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaCurriculamTypeDtos = _mapper.Map<List<BnaCurriculamTypeDto>>(UTOfficerCategories);
            var result = new PagedResult<BnaCurriculamTypeDto>(BnaCurriculamTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
