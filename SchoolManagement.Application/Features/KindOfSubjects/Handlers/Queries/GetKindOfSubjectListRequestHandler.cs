using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.KindOfSubjects;
using SchoolManagement.Application.Features.KindOfSubjects.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.KindOfSubjects.Handler.Queries
{
    public class GetKindOfSubjectListRequestHandler : IRequestHandler<GetKindOfSubjectListRequest, PagedResult<KindOfSubjectDto>>
    { 

        private readonly ISchoolManagementRepository<KindOfSubject> _KindOfSubjectRepository;   

        private readonly IMapper _mapper;  

        public GetKindOfSubjectListRequestHandler(ISchoolManagementRepository<KindOfSubject> KindOfSubjectRepository, IMapper mapper)
        {
            _KindOfSubjectRepository = KindOfSubjectRepository; 
            _mapper = mapper; 
        }

        public async Task<PagedResult<KindOfSubjectDto>> Handle(GetKindOfSubjectListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<KindOfSubject> KindOfSubject = _KindOfSubjectRepository.FilterWithInclude(x => (x.KindOfSubjectName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = KindOfSubject.Count();
            KindOfSubject = KindOfSubject.OrderByDescending(x => x.KindOfSubjectId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
             
            var KindOfSubjectDtos = _mapper.Map<List<KindOfSubjectDto>>(KindOfSubject); 
            var result = new PagedResult<KindOfSubjectDto>(KindOfSubjectDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
