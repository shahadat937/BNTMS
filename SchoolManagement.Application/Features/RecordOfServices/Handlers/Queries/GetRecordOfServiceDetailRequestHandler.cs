using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RecordOfService;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.RecordOfServices.Requests.Queries;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.RecordOfServices.Handlers.Queries
{  
    public class GetRecordOfServiceDetailRequestHandler : IRequestHandler<GetRecordOfServiceDetailRequest, RecordOfServiceDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<RecordOfService> _RecordOfServiceRepository;       
        public GetRecordOfServiceDetailRequestHandler(ISchoolManagementRepository<RecordOfService> RecordOfServiceRepository, IMapper mapper)
        {
            _RecordOfServiceRepository = RecordOfServiceRepository;    
            _mapper = mapper; 
        } 
        public async Task<RecordOfServiceDto> Handle(GetRecordOfServiceDetailRequest request, CancellationToken cancellationToken)
        {
            var RecordOfService = await _RecordOfServiceRepository.FindOneAsync(x => x.RecordOfServiceId == request.Id);    
            return _mapper.Map<RecordOfServiceDto>(RecordOfService);    
        }
    }
}
