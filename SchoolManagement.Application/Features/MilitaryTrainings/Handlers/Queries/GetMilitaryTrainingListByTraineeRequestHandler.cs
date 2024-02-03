using AutoMapper;
using SchoolManagement.Application.DTOs.MilitaryTraining;
using SchoolManagement.Application.Features.MilitaryTrainings.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.MilitaryTrainings.Handlers.Queries
{

    public class GetMilitaryTrainingListByTraineeRequestHandler : IRequestHandler<GetMilitaryTrainingListByTraineeRequest, List<MilitaryTrainingDto>>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<MilitaryTraining> _MilitaryTrainingRepository;
        public GetMilitaryTrainingListByTraineeRequestHandler(ISchoolManagementRepository<MilitaryTraining> MilitaryTrainingRepository, IMapper mapper)
        {
            _MilitaryTrainingRepository = MilitaryTrainingRepository;
            _mapper = mapper;
        }
        public async Task<List<MilitaryTrainingDto>> Handle(GetMilitaryTrainingListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var MilitaryTraining = _MilitaryTrainingRepository.FilterWithInclude(x =>x.TraineeId == request.Traineeid);
            return _mapper.Map<List<MilitaryTrainingDto>>(MilitaryTraining);
        }
    }
}
