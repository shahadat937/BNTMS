using SchoolManagement.Application.Features.HairColors.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.HairColor;
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


namespace SchoolManagement.Application.Features.HairColors.Handlers.Queries
{
    public class GetHairColorListRequestHandler : IRequestHandler<GetHairColorListRequest, PagedResult<HairColorDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.HairColor> _HairColorRepository;

        private readonly IMapper _mapper;

        public GetHairColorListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.HairColor> HairColorRepository, IMapper mapper)
        {
            _HairColorRepository = HairColorRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<HairColorDto>> Handle(GetHairColorListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.HairColor> HairColors = _HairColorRepository.FilterWithInclude(x =>x.HairColorId != 1006 && (x.HairColorName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = HairColors.Count();
            HairColors = HairColors.OrderByDescending(x => x.HairColorId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var HairColorDtos = _mapper.Map<List<HairColorDto>>(HairColors);
            var result = new PagedResult<HairColorDto>(HairColorDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
