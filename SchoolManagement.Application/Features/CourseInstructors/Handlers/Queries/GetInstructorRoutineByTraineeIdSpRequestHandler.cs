using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Queries
{
    public class GetInstructorRoutineByTraineeIdSpRequestHandler : IRequestHandler<GetInstructorRoutineByTraineeIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseInstructor> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetInstructorRoutineByTraineeIdSpRequestHandler(ISchoolManagementRepository<CourseInstructor> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetInstructorRoutineByTraineeIdSpRequest request, CancellationToken cancellationToken)
        {
            // Execute the stored procedure to get the data
            var spQuery = String.Format("exec [spGetInstructorRoutineByTraineeId] {0}", request.TraineeId);
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);

            // Apply filtering logic if a search term is provided
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                string normalizedSearchText = System.Text.RegularExpressions.Regex.Replace(request.SearchTerm, @"\s+", "").ToLower();

                var filteredRows = dataTable.AsEnumerable()
                    .Where(row =>
                    {
                        string concatenatedFields =
                            ((row["RoutineName"]?.ToString()?.Trim() ?? "") + " - " + (row["RoutineDetails"]?.ToString()?.Trim() ?? ""))
                            .Replace(" ", "").ToLower();

                        return concatenatedFields.Contains(normalizedSearchText) ||
                               (row["RoutineName"]?.ToString()?.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                               (row["RoutineDetails"]?.ToString()?.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ?? false);
                    });

                // If filtering results, create a new DataTable with the filtered rows
                if (filteredRows.Any())
                {
                    dataTable = filteredRows.CopyToDataTable();
                }
                else
                {
                    dataTable.Clear(); // Return an empty table if no rows match
                }
            }

            return dataTable;
        }

    }
}
