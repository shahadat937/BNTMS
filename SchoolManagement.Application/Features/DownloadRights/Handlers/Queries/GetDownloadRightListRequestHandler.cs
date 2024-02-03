using SchoolManagement.Application.Features.DownloadRights.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DownloadRight;
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


namespace SchoolManagement.Application.Features.DownloadRights.Handlers.Queries
{
    public class GetDownloadRightListRequestHandler : IRequestHandler<GetDownloadRightListRequest, PagedResult<DownloadRightDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DownloadRight> _DownloadRightRepository;

        private readonly IMapper _mapper;

        public GetDownloadRightListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DownloadRight> DownloadRightRepository, IMapper mapper)
        {
            _DownloadRightRepository = DownloadRightRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DownloadRightDto>> Handle(GetDownloadRightListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.DownloadRight> DownloadRights = _DownloadRightRepository.FilterWithInclude(x => (x.DownloadRightName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = DownloadRights.Count();
            DownloadRights = DownloadRights.OrderByDescending(x => x.DownloadRightId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DownloadRightDtos = _mapper.Map<List<DownloadRightDto>>(DownloadRights);
            var result = new PagedResult<DownloadRightDto>(DownloadRightDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
