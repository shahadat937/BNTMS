using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.WithdrawnDoc;
using SchoolManagement.Application.Features.WithdrawnDocs.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WithdrawnDocs.Handlers.Queries
{
    public class GetWithdrawnDocsListRequestHandler : IRequestHandler<GetWithdrawnDocsListRequest, PagedResult<WithdrawnDocDto>>
    { 

        private readonly ISchoolManagementRepository<WithdrawnDoc> _WithdrawnDocRepository;    

        private readonly IMapper _mapper;  
         
        public GetWithdrawnDocsListRequestHandler(ISchoolManagementRepository<WithdrawnDoc> WithdrawnDocRepository, IMapper mapper)
        {
            _WithdrawnDocRepository = WithdrawnDocRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<WithdrawnDocDto>> Handle(GetWithdrawnDocsListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<WithdrawnDoc> WithdrawnDocs = _WithdrawnDocRepository.FilterWithInclude(x => (x.WithdrawnDocName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = WithdrawnDocs.Count();
            WithdrawnDocs = WithdrawnDocs.OrderByDescending(x => x.WithdrawnDocId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var WithdrawnDocsDtos = _mapper.Map<List<WithdrawnDocDto>>(WithdrawnDocs); 
            var result = new PagedResult<WithdrawnDocDto>(WithdrawnDocsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
