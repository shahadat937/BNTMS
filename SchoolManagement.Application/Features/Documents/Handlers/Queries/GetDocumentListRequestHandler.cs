using SchoolManagement.Application.Features.Documents.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Document;
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


namespace SchoolManagement.Application.Features.Documents.Handlers.Queries
{
    public class GetDocumentListRequestHandler : IRequestHandler<GetDocumentListRequest, PagedResult<DocumentDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Document> _DocumentRepository;

        private readonly IMapper _mapper;

        public GetDocumentListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Document> DocumentRepository, IMapper mapper)
        {
            _DocumentRepository = DocumentRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DocumentDto>> Handle(GetDocumentListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Document> Documents = _DocumentRepository.FilterWithInclude(x => (x.DocumentName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseName", "CourseDuration", "InterServiceCourseDocType");
            var totalCount = Documents.Count();
            Documents = Documents.OrderByDescending(x => x.DocumentId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DocumentDtos = _mapper.Map<List<DocumentDto>>(Documents);
            var result = new PagedResult<DocumentDto>(DocumentDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
