using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Branchs.Handler.Queries
{
    public class GetBranchListRequestHandler : IRequestHandler<GetBranchListRequest, PagedResult<BranchDto>>
    { 

        private readonly ISchoolManagementRepository<Branch> _branchRepository; 

        private readonly IMapper _mapper;

        public GetBranchListRequestHandler(ISchoolManagementRepository<Branch> branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BranchDto>> Handle(GetBranchListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString());

            IQueryable<Branch> branches = _branchRepository.FilterWithInclude(x => x.BranchId != 17 && (x.BranchName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = branches.Count();
            branches = branches.OrderByDescending(x => x.BranchId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var branchesDtos = _mapper.Map<List<BranchDto>>(branches);
            var result = new PagedResult<BranchDto>(branchesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
