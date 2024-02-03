using SchoolManagement.Application.Contracts.Persistence;
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
using SchoolManagement.Application.Features.DocumentTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.DocumentTypes;

namespace SchoolManagement.Application.Features.DocumentTypes.Handlers.Queries
{
    public class GetDocumentTypeListRequestHandler : IRequestHandler<GetDocumentTypeListRequest, PagedResult<DocumentTypeDto>>
    {

        private readonly ISchoolManagementRepository<DocumentType> _DocumentTypeRepository;

        private readonly IMapper _mapper;

        public GetDocumentTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DocumentType> DocumentTypeRepository, IMapper mapper)
        {
            _DocumentTypeRepository = DocumentTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DocumentTypeDto>> Handle(GetDocumentTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.DocumentType> DocumentTypes = _DocumentTypeRepository.FilterWithInclude(x => (x.DocumentTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = DocumentTypes.Count();
            DocumentTypes = DocumentTypes.OrderByDescending(x => x.DocumentTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DocumentTypeDtos = _mapper.Map<List<DocumentTypeDto>>(DocumentTypes);
            var result = new PagedResult<DocumentTypeDto>(DocumentTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
