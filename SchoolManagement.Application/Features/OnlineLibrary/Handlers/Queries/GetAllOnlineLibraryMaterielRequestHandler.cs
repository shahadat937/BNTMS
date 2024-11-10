using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.OnlineLibrary;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.OnlineLibrary.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineLibrary.Handlers.Queries
{
    public class GetAllOnlineLibraryMaterielRequestHandler : IRequestHandler<GetAllOnlineLibraryMaterielRequest, PagedResult<OnlineLibraryDto>>
    {
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.OnlineLibrary> _onlineLibrary;

        private readonly IMapper _mapper;

        public GetAllOnlineLibraryMaterielRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.OnlineLibrary> onlineLibrary, IMapper mapper)
        {
            _onlineLibrary = onlineLibrary;
            _mapper = mapper;
        }
       
        public async Task<PagedResult<OnlineLibraryDto>> Handle(GetAllOnlineLibraryMaterielRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);            
                IQueryable<SchoolManagement.Domain.OnlineLibrary> OnlineLibrarys = _onlineLibrary.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText) || x.DocumentName.Contains(request.QueryParams.SearchText)),"BaseSchoolName", "DocumentType", "DownloadRight", "ShowRight");
                var totalCount = OnlineLibrarys.Count();
                OnlineLibrarys = OnlineLibrarys.OrderByDescending(x => x.OnlineLibraryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

                var OnlineLibraryDtos = _mapper.Map<List<OnlineLibraryDto>>(OnlineLibrarys);
                var result = new PagedResult<OnlineLibraryDto>(OnlineLibraryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

                return result;
            
        }
    }
}
