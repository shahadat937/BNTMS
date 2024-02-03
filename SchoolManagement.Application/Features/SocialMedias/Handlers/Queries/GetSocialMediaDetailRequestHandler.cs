using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.SocialMedias;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.SocialMedias.Requests.Queries;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.SocialMedias.Handlers.Queries
{  
    public class GetSocialMediaDetailRequestHandler : IRequestHandler<GetSocialMediaDetailRequest, SocialMediaDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<SocialMedia> _SocialMediaRepository;       
        public GetSocialMediaDetailRequestHandler(ISchoolManagementRepository<SocialMedia> SocialMediaRepository, IMapper mapper)
        {
            _SocialMediaRepository = SocialMediaRepository;    
            _mapper = mapper; 
        } 
        public async Task<SocialMediaDto> Handle(GetSocialMediaDetailRequest request, CancellationToken cancellationToken)
        {
            var SocialMedia = await _SocialMediaRepository.FindOneAsync(x => x.SocialMediaId == request.Id, "SocialMediaType");    
            return _mapper.Map<SocialMediaDto>(SocialMedia);    
        }
    }
}
