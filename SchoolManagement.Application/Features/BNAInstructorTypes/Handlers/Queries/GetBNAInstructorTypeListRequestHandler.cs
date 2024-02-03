using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaInstructorType;
using SchoolManagement.Application.Features.BnaInstructorTypes.Requests;
using SchoolManagement.Application.Features.BnaInstructorTypes.Requests.Queries;
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

namespace SchoolManagement.Application.Features.BnaInstructorTypes.Handlers.Queries
{
    public class GetBnaInstructorTypeListRequestHandler : IRequestHandler<GetBnaInstructorTypeListRequest, PagedResult<BnaInstructorTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaInstructorType> _BnaInstructorTypeRepository;

        private readonly IMapper _mapper;

        public GetBnaInstructorTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaInstructorType> BnaInstructorTypeRepository, IMapper mapper)
        {
            _BnaInstructorTypeRepository = BnaInstructorTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaInstructorTypeDto>> Handle(GetBnaInstructorTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.BnaInstructorType> BnaInstructorTypes = _BnaInstructorTypeRepository.FilterWithInclude(x => (x.InstructorTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BnaInstructorTypes.Count();
            BnaInstructorTypes = BnaInstructorTypes.OrderByDescending(x => x.BnaInstructorTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaInstructorTypeDtos = _mapper.Map<List<BnaInstructorTypeDto>>(BnaInstructorTypes);
            var result = new PagedResult<BnaInstructorTypeDto>(BnaInstructorTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
