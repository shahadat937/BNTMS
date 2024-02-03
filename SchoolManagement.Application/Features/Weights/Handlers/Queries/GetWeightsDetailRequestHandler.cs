using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.DTOs.Weight;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Application.Features.Weights.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Weights.Handlers.Queries
{  
    public class GetWeightsDetailRequestHandler : IRequestHandler<GetWeightsDetailRequest, WeightDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<Weight> _weightRepository;       
        public GetWeightsDetailRequestHandler(ISchoolManagementRepository<Weight> weightRepository, IMapper mapper)
        {
            _weightRepository = weightRepository;    
            _mapper = mapper; 
        } 
        public async Task<WeightDto> Handle(GetWeightsDetailRequest request, CancellationToken cancellationToken)
        {
            var weight = await _weightRepository.Get(request.Id);    
            return _mapper.Map<WeightDto>(weight);    
        }
    }
}
