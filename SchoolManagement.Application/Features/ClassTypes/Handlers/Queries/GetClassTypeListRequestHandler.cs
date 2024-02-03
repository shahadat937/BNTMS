using SchoolManagement.Application.Features.ClassTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ClassType;
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

using System.Text;


namespace SchoolManagement.Application.Features.ClassTypes.Handlers.Queries
{
    public class GetClassTypeListRequestHandler : IRequestHandler<GetClassTypeListRequest, PagedResult<ClassTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ClassType> _ClassTypeRepository;

        private readonly IMapper _mapper;

        public GetClassTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ClassType> ClassTypeRepository, IMapper mapper)
        {
            _ClassTypeRepository = ClassTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ClassTypeDto>> Handle(GetClassTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ClassType> ClassTypes = _ClassTypeRepository.FilterWithInclude(x => (x.ClassTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ClassTypes.Count();
            ClassTypes = ClassTypes.OrderByDescending(x => x.ClassTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ClassTypeDtos = _mapper.Map<List<ClassTypeDto>>(ClassTypes);
            var result = new PagedResult<ClassTypeDto>(ClassTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
