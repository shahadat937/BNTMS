using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Features;
using SchoolManagement.Application.Features.AppFeature.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AppFeature.Handlers.Queries
{
    public class GetFeaturesbyModeleIdRequestHandler : IRequestHandler<GetFeaturesbyModeleIdRequest, List<FeatureDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Feature> _FeatureRepository;

        public GetFeaturesbyModeleIdRequestHandler(ISchoolManagementRepository<Feature> FeatureRepository, IMapper mapper)
        {
            _FeatureRepository = FeatureRepository;
            _mapper = mapper;
        }
        public async Task<List<FeatureDto>> Handle(GetFeaturesbyModeleIdRequest request, CancellationToken cancellationToken)
        {
            var Feature =  _FeatureRepository.FilterWithInclude(x => x.ModuleId == request.ModuleId).OrderBy(x=> x.FeatureName);
            return _mapper.Map<List<FeatureDto>>(Feature);
        }
    }
}
