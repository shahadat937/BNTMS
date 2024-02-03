using SchoolManagement.Application.Features.Departments.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Department;
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


namespace SchoolManagement.Application.Features.Departments.Handlers.Queries
{
    public class GetDepartmentListRequestHandler : IRequestHandler<GetDepartmentListRequest, PagedResult<DepartmentDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Department> _DepartmentRepository;

        private readonly IMapper _mapper;

        public GetDepartmentListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Department> DepartmentRepository, IMapper mapper)
        {
            _DepartmentRepository = DepartmentRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DepartmentDto>> Handle(GetDepartmentListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Department> UTOfficerCategories = _DepartmentRepository.FilterWithInclude(x => (x.DepartmentName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.DepartmentId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DepartmentDtos = _mapper.Map<List<DepartmentDto>>(UTOfficerCategories);
            var result = new PagedResult<DepartmentDto>(DepartmentDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
