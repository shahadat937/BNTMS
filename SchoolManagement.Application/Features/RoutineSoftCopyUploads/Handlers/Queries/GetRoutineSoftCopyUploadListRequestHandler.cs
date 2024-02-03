using AutoMapper;
using SchoolManagement.Application.DTOs.RoutineSoftCopyUpload;
using SchoolManagement.Application.Features.RoutineSoftCopyUploads.Requests.Queries;
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
using System.Security.Cryptography.X509Certificates;

namespace SchoolManagement.Application.Features.RoutineSoftCopyUploads.Handlers.Queries
{
    public class GetRoutineSoftCopyUploadListRequestHandler : IRequestHandler<GetRoutineSoftCopyUploadListRequest, PagedResult<RoutineSoftCopyUploadDto>>
    {

        private readonly ISchoolManagementRepository<RoutineSoftCopyUpload> _RoutineSoftCopyUploadRepository;

        private readonly IMapper _mapper;

        public GetRoutineSoftCopyUploadListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.RoutineSoftCopyUpload> RoutineSoftCopyUploadRepository, IMapper mapper)
        {
            _RoutineSoftCopyUploadRepository = RoutineSoftCopyUploadRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<RoutineSoftCopyUploadDto>> Handle(GetRoutineSoftCopyUploadListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            //if(request.BaseSchoolNameId == 0)
            //{
                IQueryable<RoutineSoftCopyUpload> RoutineSoftCopyUploads = _RoutineSoftCopyUploadRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText))).Where(x=>x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseDurationId == request.CourseDurationId);
                var totalCount = RoutineSoftCopyUploads.Count();
                RoutineSoftCopyUploads = RoutineSoftCopyUploads.OrderByDescending(x => x.RoutineSoftCopyUploadId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

                var RoutineSoftCopyUploadDtos = _mapper.Map<List<RoutineSoftCopyUploadDto>>(RoutineSoftCopyUploads);
                var result = new PagedResult<RoutineSoftCopyUploadDto>(RoutineSoftCopyUploadDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

                return result;
            //}
            //else
            //{
            //    if(request.BaseSchoolNameId == 0)
            //    {
            //        IQueryable<RoutineSoftCopyUpload> RoutineSoftCopyUploads = _RoutineSoftCopyUploadRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseName", "BaseSchoolName", "DocumentType", "DownloadRight", "RoutineSoftCopyUploadTitle", "ShowRight");
            //        var totalCount = RoutineSoftCopyUploads.Count();
            //        RoutineSoftCopyUploads = RoutineSoftCopyUploads.OrderByDescending(x => x.RoutineSoftCopyUploadId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            //        var RoutineSoftCopyUploadDtos = _mapper.Map<List<RoutineSoftCopyUploadDto>>(RoutineSoftCopyUploads);
            //        var result = new PagedResult<RoutineSoftCopyUploadDto>(RoutineSoftCopyUploadDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            //        return result;
            //    }
            //    else
            //    {
            //        IQueryable<RoutineSoftCopyUpload> RoutineSoftCopyUploads = _RoutineSoftCopyUploadRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText) && (x.BaseSchoolNameId == request.BaseSchoolNameId)), "CourseName", "BaseSchoolName", "DocumentType", "DownloadRight", "RoutineSoftCopyUploadTitle", "ShowRight");
            //        var totalCount = RoutineSoftCopyUploads.Count();
            //        RoutineSoftCopyUploads = RoutineSoftCopyUploads.OrderByDescending(x => x.RoutineSoftCopyUploadId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            //        var RoutineSoftCopyUploadDtos = _mapper.Map<List<RoutineSoftCopyUploadDto>>(RoutineSoftCopyUploads);
            //        var result = new PagedResult<RoutineSoftCopyUploadDto>(RoutineSoftCopyUploadDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            //        return result;
            //    }
                
            //}

            //var RoutineSoftCopyUploadDtos = _mapper.Map<List<RoutineSoftCopyUploadDto>>(RoutineSoftCopyUploads);
            //var result = new PagedResult<RoutineSoftCopyUploadDto>(RoutineSoftCopyUploadDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            //return result;


        }
    }
}
