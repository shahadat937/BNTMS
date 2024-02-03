using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NewEntryEvaluation;
using SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NewEntryEvaluations.Handlers.Queries
{
    public class GetNewEntryEvaluationDetailRequestHandler : IRequestHandler<GetNewEntryEvaluationDetailRequest, NewEntryEvaluationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.NewEntryEvaluation> _NewEntryEvaluationRepository;
        public GetNewEntryEvaluationDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.NewEntryEvaluation> NewEntryEvaluationRepository, IMapper mapper)
        {
            _NewEntryEvaluationRepository = NewEntryEvaluationRepository;
            _mapper = mapper;
        }
        public async Task<NewEntryEvaluationDto> Handle(GetNewEntryEvaluationDetailRequest request, CancellationToken cancellationToken)
        {
            var NewEntryEvaluation = await _NewEntryEvaluationRepository.Get(request.NewEntryEvaluationId);
            return _mapper.Map<NewEntryEvaluationDto>(NewEntryEvaluation);
        }
    }
}
