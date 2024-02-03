using AutoMapper;
using SchoolManagement.Application.DTOs.SocialMedias;
using SchoolManagement.Application.Features.SocialMedias.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.SocialMedias.Handlers.Queries
{

    public class GetSocialMediaListByTraineeRequestHandler : IRequestHandler<GetSocialMediaListByTraineeRequest, List<SocialMediaDto>>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<SocialMedia> _SocialMediaRepository;
        public GetSocialMediaListByTraineeRequestHandler(ISchoolManagementRepository<SocialMedia> SocialMediaRepository, IMapper mapper)
        {
            _SocialMediaRepository = SocialMediaRepository;
            _mapper = mapper;
        }
        public async Task<List<SocialMediaDto>> Handle(GetSocialMediaListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var SocialMedia = _SocialMediaRepository.FilterWithInclude(x =>x.TraineeId == request.Traineeid, "SocialMediaType");
            return _mapper.Map<List<SocialMediaDto>>(SocialMedia);
        }
    }
}
