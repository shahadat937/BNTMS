using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeBioDataOther;
using SchoolManagement.Application.Features.TraineeBioDataOthers.Requests;
using SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Queries;
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

namespace SchoolManagement.Application.Features.TraineeBioDataOthers.Handlers.Queries
{
    public class GetTraineeBioDataOtherListRequestHandler : IRequestHandler<GetTraineeBioDataOtherListRequest, PagedResult<TraineeBioDataOtherDto>>
    {
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataOther> _TraineeBioDataOtherRepository;

        private readonly IMapper _mapper;

        public GetTraineeBioDataOtherListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataOther> TraineeBioDataOtherRepository, IMapper mapper)
        {
            _TraineeBioDataOtherRepository = TraineeBioDataOtherRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineeBioDataOtherDto>> Handle(GetTraineeBioDataOtherListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TraineeBioDataOther> UTOfficerCategories = _TraineeBioDataOtherRepository.FilterWithInclude(x => (x.PermanentAddress.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.TraineeBioDataOtherId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TraineeBioDataOtherDtos = _mapper.Map<List<TraineeBioDataOtherDto>>(UTOfficerCategories);
            var result = new PagedResult<TraineeBioDataOtherDto>(TraineeBioDataOtherDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
