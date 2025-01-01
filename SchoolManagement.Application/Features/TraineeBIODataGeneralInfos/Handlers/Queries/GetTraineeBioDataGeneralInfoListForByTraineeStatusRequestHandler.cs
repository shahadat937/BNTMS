using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Requests.Queries;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Handlers.Queries
{
    public class GetTraineeBioDataGeneralInfoListForByTraineeStatusRequestHandler : IRequestHandler<GetTraineeBioDataGeneralInfoListForByTraineeStatusRequest, PagedResult<TraineeBioDataGeneralInfoDto>>
    {
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;

        private readonly IMapper _mapper;
        public GetTraineeBioDataGeneralInfoListForByTraineeStatusRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository, IMapper mapper)
        {
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineeBioDataGeneralInfoDto>> Handle(GetTraineeBioDataGeneralInfoListForByTraineeStatusRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos = _TraineeBioDataGeneralInfoRepository.FilterWithInclude(x => x.TraineeStatusId == request.TraineeStatusId && ((x.Pno.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText))), "BnaBatch", "TraineeStatus", "Rank", "Country");
            var totalCount = TraineeBioDataGeneralInfos.Count();
            TraineeBioDataGeneralInfos = TraineeBioDataGeneralInfos.OrderByDescending(x => x.TraineeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TraineeBioDataGeneralInfoDtos = _mapper.Map<List<TraineeBioDataGeneralInfoDto>>(TraineeBioDataGeneralInfos);
            var result = new PagedResult<TraineeBioDataGeneralInfoDto>(TraineeBioDataGeneralInfoDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
