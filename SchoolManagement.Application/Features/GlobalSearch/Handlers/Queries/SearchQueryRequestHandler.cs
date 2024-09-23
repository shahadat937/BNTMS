using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.GlobalSearch.Requests.Queries;
using SchoolManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SchoolManagement.Application.DTOs.GlobalSearch;

namespace SchoolManagement.Application.Features.GlobalSearch.Handlers.Queries
{
    public class SearchQueryRequestHandler: IRequestHandler<SearchQueryRequest,object>
    {
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeNomination> _repository;
        private readonly IMapper _mapper;

        public SearchQueryRequestHandler(ISchoolManagementRepository<Domain.TraineeNomination> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<object> Handle(SearchQueryRequest request, CancellationToken cancellationToken)
        {
            if(request.Query==null)
            {
                request.Query = "";
            }

            var trainee = _repository.ExecWithSqlQuery($"EXEC [dbo].[spTraineeSearch] @query='{request.Query}'");

            List<Dictionary<string, object>> traineeRows = trainee.AsEnumerable()
                        .Select(row => trainee.Columns.Cast<DataColumn>()
                        .ToDictionary(col => col.ColumnName, col => row[col]))
                        .ToList();

            var instructor = _repository.ExecWithSqlQuery($"EXEC [dbo].[spInstructorSearch] @query='{request.Query}'");

            List<Dictionary<string, object>> instructorRows = instructor.AsEnumerable()
            .Select(row => instructor.Columns.Cast<DataColumn>()
            .ToDictionary(col => col.ColumnName, col => row[col]))
            .ToList();



            var result = new QueryResultDto();
            result.Query = request.Query;
            result.Results.AddRange(traineeRows);
            result.Results.AddRange(instructorRows);
            result.ResponseCount = result.Results.Count;
            

            return result;
        }
    }
}
