using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.SocialMediaTypes;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Application.Features.SocialMediaTypes.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SocialMediaTypes.Handlers.Queries
{  
    public class GetSocialMediaTypeDetailRequestHandler : IRequestHandler<GetSocialMediaTypeDetailRequest, SocialMediaTypeDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<SocialMediaType> _SocialMediaTypeRepository;       
        public GetSocialMediaTypeDetailRequestHandler(ISchoolManagementRepository<SocialMediaType> SocialMediaTypeRepository, IMapper mapper)
        {
            _SocialMediaTypeRepository = SocialMediaTypeRepository;    
            _mapper = mapper; 
        } 
        public async Task<SocialMediaTypeDto> Handle(GetSocialMediaTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var SocialMediaType = await _SocialMediaTypeRepository.Get(request.Id);    
            return _mapper.Map<SocialMediaTypeDto>(SocialMediaType);    
        }
    }
}
