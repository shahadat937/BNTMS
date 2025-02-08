using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeCountByTraineeStatusRequestHandler : IRequestHandler<GetTraineeCountByTraineeStatusRequest, object>
    {
        private readonly ISchoolManagementRepository<TraineeNomination> _trineeNominationRepository;
        public GetTraineeCountByTraineeStatusRequestHandler(ISchoolManagementRepository<TraineeNomination> trineeNominationRepository)
        {
            _trineeNominationRepository = trineeNominationRepository;
        }
        public async Task<object> Handle(GetTraineeCountByTraineeStatusRequest request, CancellationToken cancellationToken)
        {
            var sqlQuery = String.Format("Exec [spGetTraineeCountByTraineeType]");
            DataTable dataTable = _trineeNominationRepository.ExecWithSqlQuery(sqlQuery);
            return dataTable;
        }
    }
}
