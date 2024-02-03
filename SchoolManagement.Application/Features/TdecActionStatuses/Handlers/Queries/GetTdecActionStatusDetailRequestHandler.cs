using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TdecActionStatus;
using SchoolManagement.Application.Features.TdecActionStatuses.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecActionStatuses.Handlers.Queries
{
    public class GetTdecActionStatusDetailRequestHandler : IRequestHandler<GetTdecActionStatusDetailRequest, TdecActionStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TdecActionStatus> _TdecActionStatusRepository;
        public GetTdecActionStatusDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TdecActionStatus> TdecActionStatusRepository, IMapper mapper)
        {
            _TdecActionStatusRepository = TdecActionStatusRepository;
            _mapper = mapper;
        }
        public async Task<TdecActionStatusDto> Handle(GetTdecActionStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var TdecActionStatus = await _TdecActionStatusRepository.Get(request.TdecActionStatusId);
            return _mapper.Map<TdecActionStatusDto>(TdecActionStatus);
        }
    }
}
