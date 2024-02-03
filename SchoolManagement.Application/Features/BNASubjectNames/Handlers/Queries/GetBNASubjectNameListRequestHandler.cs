using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.DTOs.BnaSubjectName;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries 
{ 
    public class GetBnaSubjectNameListRequestHandler : IRequestHandler<GetBnaSubjectNameListRequest, PagedResult<BnaSubjectNameDto>>
    { 

        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;    

        private readonly IMapper _mapper;  
         
        public GetBnaSubjectNameListRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, IMapper mapper)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<BnaSubjectNameDto>> Handle(GetBnaSubjectNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<BnaSubjectName> BnaSubjectNames = _BnaSubjectNameRepository.FilterWithInclude(x => (x.SubjectName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "SubjectCategory", "BnaSubjectCurriculum", "SubjectType", "KindOfSubject", "SubjectClassification", "ResultStatus");
            var totalCount = BnaSubjectNames.Count();
            BnaSubjectNames = BnaSubjectNames.Where(x=>x.Status== request.Status).OrderBy(x => x.BnaSubjectNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var BnaSubjectNamesDtos = _mapper.Map<List<BnaSubjectNameDto>>(BnaSubjectNames); 
            var result = new PagedResult<BnaSubjectNameDto>(BnaSubjectNamesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);
             
            return result;
        }
    }
}
