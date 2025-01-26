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
    public class GetRunningCivilTraineeRequestHandler : IRequestHandler<GetRunningCivilTraineeRequest, object>
    {


        private readonly ISchoolManagementRepository<TraineeNomination> _trineeNominationRepository;
        public GetRunningCivilTraineeRequestHandler(ISchoolManagementRepository<TraineeNomination> trineeNominationRepository)
        {
            _trineeNominationRepository = trineeNominationRepository;
        }
        public async Task<object> Handle(GetRunningCivilTraineeRequest request, CancellationToken cancellationToken)
        {
            var searchText = $"'{request.SearchText}'".Replace("'","''");
            var sqlQuery = String.Format("Exec [spGetRunningCivilTrainees] {0}", request.SearchText);
            DataTable dataTable = _trineeNominationRepository.ExecWithSqlQuery(sqlQuery);
            return dataTable;
        }
    }
}
