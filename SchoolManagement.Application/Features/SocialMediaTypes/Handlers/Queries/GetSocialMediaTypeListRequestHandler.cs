using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.SocialMediaTypes;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Application.Features.SocialMediaTypes.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SocialMediaTypes.Handlers.Queries 
{ 
    public class GetSocialMediaTypeListRequestHandler : IRequestHandler<GetSocialMediaTypeListRequest, PagedResult<SocialMediaTypeDto>>
    { 

        private readonly ISchoolManagementRepository<SocialMediaType> _SocialMediaTypeRepository;    

        private readonly IMapper _mapper;  
         
        public GetSocialMediaTypeListRequestHandler(ISchoolManagementRepository<SocialMediaType> SocialMediaTypeRepository, IMapper mapper)
        {
            _SocialMediaTypeRepository = SocialMediaTypeRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<SocialMediaTypeDto>> Handle(GetSocialMediaTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<SocialMediaType> SocialMediaTypes = _SocialMediaTypeRepository.FilterWithInclude(x => (x.SocialMediaTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = SocialMediaTypes.Count();
            SocialMediaTypes = SocialMediaTypes.OrderByDescending(x => x.SocialMediaTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var SocialMediaTypesDtos = _mapper.Map<List<SocialMediaTypeDto>>(SocialMediaTypes); 
            var result = new PagedResult<SocialMediaTypeDto>(SocialMediaTypesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
