using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TdecQuestionName;
using SchoolManagement.Application.Features.TdecQuestionNames.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecQuestionNames.Handlers.Queries
{
    public class GetTdecQuestionNameDetailRequestHandler : IRequestHandler<GetTdecQuestionNameDetailRequest, TdecQuestionNameDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TdecQuestionName> _TdecQuestionNameRepository;
        public GetTdecQuestionNameDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TdecQuestionName> TdecQuestionNameRepository, IMapper mapper)
        {
            _TdecQuestionNameRepository = TdecQuestionNameRepository;
            _mapper = mapper;
        }
        public async Task<TdecQuestionNameDto> Handle(GetTdecQuestionNameDetailRequest request, CancellationToken cancellationToken)
        {
            var TdecQuestionName = await _TdecQuestionNameRepository.Get(request.TdecQuestionNameId);
            return _mapper.Map<TdecQuestionNameDto>(TdecQuestionName);
        }
    }
}
