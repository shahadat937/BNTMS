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
    public class GetRunningTraineeByTraineeStatusRequestHandler : IRequestHandler<GetRunningTraineeByTraineeStatusRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeNomination> _trineeNominationRepository;
        public GetRunningTraineeByTraineeStatusRequestHandler(ISchoolManagementRepository<TraineeNomination> trineeNominationRepository)
        {
            _trineeNominationRepository = trineeNominationRepository;
        }
        public async Task<object> Handle(GetRunningTraineeByTraineeStatusRequest request, CancellationToken cancellationToken)
        {

            var sqlQuery = "Exec [spGetRunningCourseTrainees] @TraineeStatusId, @OfficerTypeId, @SearchText";

            // Dynamically build the SQL query string with values directly
            sqlQuery = sqlQuery.Replace("@TraineeStatusId", request.TraineeStatusId.ToString())
                               .Replace("@OfficerTypeId", (request.OfficerTypeId == 0 ? "NULL" : request.OfficerTypeId.ToString()))
                               .Replace("@SearchText", (string.IsNullOrEmpty(request.SearchText) ? "NULL" : $"'{request.SearchText}'"));

            // Execute the query with the dynamically built string
            DataTable dataTable =  _trineeNominationRepository.ExecWithSqlQuery(sqlQuery);
            return dataTable;
        }
    }
}
