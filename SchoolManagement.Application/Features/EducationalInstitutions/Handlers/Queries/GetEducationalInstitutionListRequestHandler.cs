using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.EducationalInstitutions;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Application.Features.EducationalInstitutions.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EducationalInstitutions.Handlers.Queries 
{ 
    public class GetEducationalInstitutionListRequestHandler : IRequestHandler<GetEducationalInstitutionListRequest, PagedResult<EducationalInstitutionDto>>
    { 

        private readonly ISchoolManagementRepository<EducationalInstitution> _EducationalInstitutionRepository;    

        private readonly IMapper _mapper;  
         
        public GetEducationalInstitutionListRequestHandler(ISchoolManagementRepository<EducationalInstitution> EducationalInstitutionRepository, IMapper mapper)
        {
            _EducationalInstitutionRepository = EducationalInstitutionRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<EducationalInstitutionDto>> Handle(GetEducationalInstitutionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<EducationalInstitution> EducationalInstitutions = _EducationalInstitutionRepository.FilterWithInclude(x => (x.InstituteName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = EducationalInstitutions.Count();
            EducationalInstitutions = EducationalInstitutions.OrderByDescending(x => x.EducationalInstitutionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var EducationalInstitutionsDtos = _mapper.Map<List<EducationalInstitutionDto>>(EducationalInstitutions); 
            var result = new PagedResult<EducationalInstitutionDto>(EducationalInstitutionsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
