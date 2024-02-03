using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Electeds;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Application.Features.Electeds.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Electeds.Handlers.Queries
{  
    public class GetElectedDetailRequestHandler : IRequestHandler<GetElectedDetailRequest, ElectedDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<Elected> _ElectedRepository;       
        public GetElectedDetailRequestHandler(ISchoolManagementRepository<Elected> ElectedRepository, IMapper mapper)
        {
            _ElectedRepository = ElectedRepository;    
            _mapper = mapper; 
        } 
        public async Task<ElectedDto> Handle(GetElectedDetailRequest request, CancellationToken cancellationToken)
        {
            var Elected = await _ElectedRepository.Get(request.Id);    
            return _mapper.Map<ElectedDto>(Elected);    
        }
    }
}
