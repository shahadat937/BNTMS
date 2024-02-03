using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ReasonType;
using SchoolManagement.Application.Features.ReasonTypes.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReasonTypes.Handlers.Queries
{
    public class GetReasonTypeDetailRequestHandler : IRequestHandler<GetReasonTypeDetailRequest, ReasonTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ReasonType> _ReasonTypeRepository;
        public GetReasonTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ReasonType> ReasonTypeRepository, IMapper mapper)
        {
            _ReasonTypeRepository = ReasonTypeRepository;
            _mapper = mapper;
        }
        public async Task<ReasonTypeDto> Handle(GetReasonTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ReasonType = await _ReasonTypeRepository.Get(request.ReasonTypeId);
            return _mapper.Map<ReasonTypeDto>(ReasonType);
        }
    }
}
