using SchoolManagement.Application.Features.SaylorBranchs.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
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
using SchoolManagement.Application.DTOs.SaylorBranch;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SaylorBranchs.Handlers.Queries
{
    public class GetSaylorBranchListRequestHandler : IRequestHandler<GetSaylorBranchListRequest, PagedResult<SaylorBranchDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SaylorBranch> _SaylorBranchRepository;

        private readonly IMapper _mapper;

        public GetSaylorBranchListRequestHandler(ISchoolManagementRepository<SaylorBranch> SaylorBranchRepository, IMapper mapper)
        {
            _SaylorBranchRepository = SaylorBranchRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SaylorBranchDto>> Handle(GetSaylorBranchListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SaylorBranch> SaylorBranchs = _SaylorBranchRepository.FilterWithInclude(x =>x.SaylorBranchId != 20 && (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = SaylorBranchs.Count();
            SaylorBranchs = SaylorBranchs.OrderByDescending(x => x.SaylorBranchId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SaylorBranchDtos = _mapper.Map<List<SaylorBranchDto>>(SaylorBranchs);
            var result = new PagedResult<SaylorBranchDto>(SaylorBranchDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
