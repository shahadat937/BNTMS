using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using MediatR;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries
{
    public class GetTraineeBioDataGeneralInfoListForForeignRequestHandler : IRequestHandler<GetTraineeBioDataGeneralInfoListForForeignRequest, PagedResult<TraineeBioDataGeneralInfoDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;

        private readonly IMapper _mapper;

        public GetTraineeBioDataGeneralInfoListForForeignRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository, IMapper mapper)
        {
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineeBioDataGeneralInfoDto>> Handle(GetTraineeBioDataGeneralInfoListForForeignRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos = _TraineeBioDataGeneralInfoRepository.FilterWithInclude(x => (x.OfficerTypeId !=1) && ((x.Pno.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText))), "BnaBatch", "TraineeStatus", "Rank", "Country");
            var totalCount = TraineeBioDataGeneralInfos.Count();
            TraineeBioDataGeneralInfos = TraineeBioDataGeneralInfos.OrderByDescending(x => x.TraineeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TraineeBioDataGeneralInfoDtos = _mapper.Map<List<TraineeBioDataGeneralInfoDto>>(TraineeBioDataGeneralInfos);
            var result = new PagedResult<TraineeBioDataGeneralInfoDto>(TraineeBioDataGeneralInfoDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
