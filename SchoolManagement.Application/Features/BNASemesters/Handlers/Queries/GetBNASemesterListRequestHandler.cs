using SchoolManagement.Application.Features.BnaSemesters.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSemester;
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


namespace SchoolManagement.Application.Features.BnaSemesters.Handlers.Queries
{
    public class GetBnaSemesterListRequestHandler : IRequestHandler<GetBnaSemesterListRequest, PagedResult<BnaSemesterDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaSemester> _BnaSemesterRepository;

        private readonly IMapper _mapper;

        public GetBnaSemesterListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaSemester> BnaSemesterRepository, IMapper mapper)
        {
            _BnaSemesterRepository = BnaSemesterRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaSemesterDto>> Handle(GetBnaSemesterListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.BnaSemester> UTOfficerCategories = _BnaSemesterRepository.FilterWithInclude(x => (x.SemesterName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.BnaSemesterId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaSemesterDtos = _mapper.Map<List<BnaSemesterDto>>(UTOfficerCategories);
            var result = new PagedResult<BnaSemesterDto>(BnaSemesterDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
