using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeNomination;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeNominationDetailRequestHandler : IRequestHandler<GetTraineeNominationDetailRequest, TraineeNominationDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeNomination> _TraineeNominationRepository;
        public GetTraineeNominationDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeNomination> TraineeNominationRepository, IMapper mapper)
        {
            _TraineeNominationRepository = TraineeNominationRepository;
            _mapper = mapper;
        }
        public async Task<TraineeNominationDto> Handle(GetTraineeNominationDetailRequest request, CancellationToken cancellationToken)
        {
            var TraineeNomination = _TraineeNominationRepository.FinedOneInclude(x => x.TraineeNominationId == request.TraineeNominationId,"Trainee", "CourseDuration", "CourseName");
            return _mapper.Map<TraineeNominationDto>(TraineeNomination);
        }
    }
}
