using AutoMapper;
using SchoolManagement.Application.DTOs.ReadingMaterial;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Queries
{
    public class GetReadingMaterialListRequestHandler : IRequestHandler<GetReadingMaterialListRequest, PagedResult<ReadingMaterialDto>>
    {

        private readonly ISchoolManagementRepository<ReadingMaterial> _ReadingMaterialRepository;

        private readonly IMapper _mapper;

        public GetReadingMaterialListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ReadingMaterial> ReadingMaterialRepository, IMapper mapper)
        {
            _ReadingMaterialRepository = ReadingMaterialRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ReadingMaterialDto>> Handle(GetReadingMaterialListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            if(request.BaseSchoolNameId == 0)
            {
                IQueryable<ReadingMaterial> ReadingMaterials = _ReadingMaterialRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseName", "BaseSchoolName", "DocumentType", "DownloadRight", "ReadingMaterialTitle", "ShowRight");
                var totalCount = ReadingMaterials.Count();
                ReadingMaterials = ReadingMaterials.OrderByDescending(x => x.ReadingMaterialId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

                var ReadingMaterialDtos = _mapper.Map<List<ReadingMaterialDto>>(ReadingMaterials);
                var result = new PagedResult<ReadingMaterialDto>(ReadingMaterialDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

                return result;
            }
            else
            {
                if(request.BaseSchoolNameId == 0)
                {
                    IQueryable<ReadingMaterial> ReadingMaterials = _ReadingMaterialRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseName", "BaseSchoolName", "DocumentType", "DownloadRight", "ReadingMaterialTitle", "ShowRight");
                    var totalCount = ReadingMaterials.Count();
                    ReadingMaterials = ReadingMaterials.OrderByDescending(x => x.ReadingMaterialId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

                    var ReadingMaterialDtos = _mapper.Map<List<ReadingMaterialDto>>(ReadingMaterials);
                    var result = new PagedResult<ReadingMaterialDto>(ReadingMaterialDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

                    return result;
                }
                else
                {
                    IQueryable<ReadingMaterial> ReadingMaterials = _ReadingMaterialRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText) && (x.BaseSchoolNameId == request.BaseSchoolNameId)), "CourseName", "BaseSchoolName", "DocumentType", "DownloadRight", "ReadingMaterialTitle", "ShowRight");
                    var totalCount = ReadingMaterials.Count();
                    ReadingMaterials = ReadingMaterials.OrderByDescending(x => x.ReadingMaterialId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

                    var ReadingMaterialDtos = _mapper.Map<List<ReadingMaterialDto>>(ReadingMaterials);
                    var result = new PagedResult<ReadingMaterialDto>(ReadingMaterialDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

                    return result;
                }
                
            }

            //var ReadingMaterialDtos = _mapper.Map<List<ReadingMaterialDto>>(ReadingMaterials);
            //var result = new PagedResult<ReadingMaterialDto>(ReadingMaterialDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            //return result;


        }
    }
}
