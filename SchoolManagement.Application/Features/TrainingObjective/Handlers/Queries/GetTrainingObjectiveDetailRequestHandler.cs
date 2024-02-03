using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TrainingObjective;
using SchoolManagement.Application.Features.TrainingObjectives.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TrainingObjectives.Handlers.Queries
{
    public class GetTrainingObjectiveDetailRequestHandler : IRequestHandler<GetTrainingObjectiveDetailRequest, TrainingObjectiveDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TrainingObjective> _TrainingObjectiveRepository;
        public GetTrainingObjectiveDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TrainingObjective> TrainingObjectiveRepository, IMapper mapper)
        {
            _TrainingObjectiveRepository = TrainingObjectiveRepository;
            _mapper = mapper;
        }
        public async Task<TrainingObjectiveDto> Handle(GetTrainingObjectiveDetailRequest request, CancellationToken cancellationToken)
        {
            var TrainingObjective = _TrainingObjectiveRepository.FinedOneInclude(x=>x.TrainingObjectiveId==request.TrainingObjectiveId, "CourseName");
            return _mapper.Map<TrainingObjectiveDto>(TrainingObjective);
        }
    }
}
