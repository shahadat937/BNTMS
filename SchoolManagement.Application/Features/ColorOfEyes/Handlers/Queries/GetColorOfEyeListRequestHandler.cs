using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ColorOfEye;
using SchoolManagement.Application.Features.ColorOfEyes.Requests.Queries;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.ColorOfEyes.Handlers.Queries
{
    public class GetColorOfEyeListRequestHandler : IRequestHandler<GetColorOfEyeListRequest, PagedResult<ColorOfEyeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ColorOfEye> _ColorOfEyeRepository;

        private readonly IMapper _mapper;

        public GetColorOfEyeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ColorOfEye> ColorOfEyeRepository, IMapper mapper)
        {
            _ColorOfEyeRepository = ColorOfEyeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ColorOfEyeDto>> Handle(GetColorOfEyeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ColorOfEye> ColorOfEyes = _ColorOfEyeRepository.FilterWithInclude(x =>x.ColorOfEyeId != 1010 &&  (x.ColorOfEyeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ColorOfEyes.Count();
            ColorOfEyes = ColorOfEyes.OrderByDescending(x => x.ColorOfEyeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ColorOfEyeDtos = _mapper.Map<List<ColorOfEyeDto>>(ColorOfEyes);
            var result = new PagedResult<ColorOfEyeDto>(ColorOfEyeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
