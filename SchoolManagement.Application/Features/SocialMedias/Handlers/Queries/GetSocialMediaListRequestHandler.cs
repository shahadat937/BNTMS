using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.SocialMedias;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.SocialMedias.Requests.Queries;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.SocialMedias.Handlers.Queries 
{ 
    public class GetSocialMediaListRequestHandler : IRequestHandler<GetSocialMediaListRequest, PagedResult<SocialMediaDto>>
    { 

        private readonly ISchoolManagementRepository<SocialMedia> _SocialMediaRepository;    

        private readonly IMapper _mapper;  
         
        public GetSocialMediaListRequestHandler(ISchoolManagementRepository<SocialMedia> SocialMediaRepository, IMapper mapper)
        {
            _SocialMediaRepository = SocialMediaRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<SocialMediaDto>> Handle(GetSocialMediaListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<SocialMedia> SocialMedias = _SocialMediaRepository.FilterWithInclude(x => (x.SocialMediaAccountName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = SocialMedias.Count();
            SocialMedias = SocialMedias.OrderByDescending(x => x.SocialMediaId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var SocialMediasDtos = _mapper.Map<List<SocialMediaDto>>(SocialMedias); 
            var result = new PagedResult<SocialMediaDto>(SocialMediasDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
