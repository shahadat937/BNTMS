using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.CodeValues.Requests.Queries;

namespace SchoolManagement.Application.Features.CodeValues.Handlers.Queries
{  
    public class GetCodeValueDetailRequestHandler : IRequestHandler<GetCodeValueDetailRequest, CodeValueDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<CodeValue> _CodeValueRepository;       
        public GetCodeValueDetailRequestHandler(ISchoolManagementRepository<CodeValue> CodeValueRepository, IMapper mapper)
        {
            _CodeValueRepository = CodeValueRepository;    
            _mapper = mapper; 
        } 
        public async Task<CodeValueDto> Handle(GetCodeValueDetailRequest request, CancellationToken cancellationToken)
        {
            var CodeValue = await _CodeValueRepository.Get(request.Id);    
            return _mapper.Map<CodeValueDto>(CodeValue);    
        }
    }
}
