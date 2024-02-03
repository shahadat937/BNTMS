using SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Queries;
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
using SchoolManagement.Application.DTOs.SaylorSubBranch;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Handlers.Queries
{
    public class GetSaylorSubBranchListRequestHandler : IRequestHandler<GetSaylorSubBranchListRequest, PagedResult<SaylorSubBranchDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SaylorSubBranch> _SaylorSubBranchRepository;

        private readonly IMapper _mapper;

        public GetSaylorSubBranchListRequestHandler(ISchoolManagementRepository<SaylorSubBranch> SaylorSubBranchRepository, IMapper mapper)
        {
            _SaylorSubBranchRepository = SaylorSubBranchRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SaylorSubBranchDto>> Handle(GetSaylorSubBranchListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SaylorSubBranch> SaylorSubBranchs = _SaylorSubBranchRepository.FilterWithInclude(x =>x.SaylorSubBranchId != 23 && (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "SaylorBranch");
            var totalCount = SaylorSubBranchs.Count();
            SaylorSubBranchs = SaylorSubBranchs.OrderBy(x => x.MenuPosition).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SaylorSubBranchDtos = _mapper.Map<List<SaylorSubBranchDto>>(SaylorSubBranchs);
            var result = new PagedResult<SaylorSubBranchDto>(SaylorSubBranchDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
