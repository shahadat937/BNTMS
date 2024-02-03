using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using System.Data;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetRoutineSoftCopyUploadSpRequestHandler : IRequestHandler<GetRoutineSoftCopyUploadSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeNomination> _TraineeNominationRepository;

        private readonly IMapper _mapper;

        public GetRoutineSoftCopyUploadSpRequestHandler(ISchoolManagementRepository<TraineeNomination> TraineeNominationRepository, IMapper mapper)
        {
            _TraineeNominationRepository = TraineeNominationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetRoutineSoftCopyUploadSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetRoutineSoftCopyByTrainee] {0}", request.TraineeId);
            
            DataTable dataTable = _TraineeNominationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
