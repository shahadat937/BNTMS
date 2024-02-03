using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.ReadingMaterialTitle;
using SchoolManagement.Application.Features.ReadingMaterialTitles.Requests;
using SchoolManagement.Application.Features.ReadingMaterialTitles.Requests.Queries;
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
using SchoolManagement.Application.DTOs.ReadingMaterialTitles;

namespace SchoolManagement.Application.Features.ReadingMaterialTitles.Handlers.Queries
{
    public class GetReadingMaterialTitleListRequestHandler : IRequestHandler<GetReadingMaterialTitleListRequest, PagedResult<ReadingMaterialTitleDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ReadingMaterialTitle> _ReadingMaterialTitleRepository;

        private readonly IMapper _mapper;

        public GetReadingMaterialTitleListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ReadingMaterialTitle> ReadingMaterialTitleRepository, IMapper mapper)
        {
            _ReadingMaterialTitleRepository = ReadingMaterialTitleRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ReadingMaterialTitleDto>> Handle(GetReadingMaterialTitleListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ReadingMaterialTitle> ReadingMaterialTitles = _ReadingMaterialTitleRepository.FilterWithInclude(x => (x.Title.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ReadingMaterialTitles.Count();
            ReadingMaterialTitles = ReadingMaterialTitles.OrderByDescending(x => x.ReadingMaterialTitleId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ReadingMaterialTitleDtos = _mapper.Map<List<ReadingMaterialTitleDto>>(ReadingMaterialTitles);
            var result = new PagedResult<ReadingMaterialTitleDto>(ReadingMaterialTitleDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
