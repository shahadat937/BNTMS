using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.GlobalSearch.Requests.Queries;
using SchoolManagement.Application.Exceptions;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SchoolManagement.Application.DTOs.GlobalSearch;
using AutoMapper.QueryableExtensions.Impl;
using SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Constants;
using SchoolManagement.Domain;
using SchoolManagement.Application.Contracts.Identity;

namespace SchoolManagement.Application.Features.GlobalSearch.Handlers.Queries
{
    public class SearchQueryRequestHandler: IRequestHandler<SearchQueryRequest,object>
    {
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeNomination> _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public SearchQueryRequestHandler(ISchoolManagementRepository<Domain.TraineeNomination> repository, IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IUserService userService)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task<object> Handle(SearchQueryRequest request, CancellationToken cancellationToken)
        {
            string traineeCountQuery = $"EXEC [dbo].[spTraineeSearchCount] @query='{request.Query.keyword}'";
            string traineeQuery = $"EXEC [dbo].[spTraineeSearch] @query=N'{request.Query.keyword}'";
            string instructorCountQuery = $"EXEC [dbo].[spInstructorSearchCount] @query='{request.Query.keyword}'";
            string instructorQuery = $"EXEC [dbo].[spInstructorSearch] @query=N'{request.Query.keyword}'";

            // Get which type of data to get
            //bool needTrainee = request.Query.Filters.Where(x => x == "trainee").Any();
            //bool needInstructor = request.Query.Filters.Where(x => x == "instructor").Any();
            // bool needCourse = request.Query.Filters.Where(x => x == "course").Any();


            // getting the current user and setting the access level
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            List<string> branchId = new List<string> { "NULL", "NULL", "NULL"};
            if(userId != null)
            {
                var user = await _userService.GetUserById(userId);
                if(user!=null&&user.SecondLevel!=null)
                {
                    branchId[0] = user.SecondLevel.ToString();
                }

                if(user!=null&&user.ThirdLevel!=null)
                {
                    branchId[1] = user.ThirdLevel.ToString();
                }

                if(user!=null&&user.FourthLevel!=null)
                {
                    branchId[2] = user.FourthLevel.ToString();
                }
            }


            if(request.Query.keyword==null)
            {
                request.Query.keyword = "";
            }

            List<string> queriesForCount = GetQueriesForCount(request.Query.Filters, request.Query.keyword,branchId);
            List<string> queries = GetQueriesForResult(request.Query.Filters, request.Query.keyword);


            List<int> counts = new List<int>();
            List<int> prefSum = new List<int>();
            prefSum.Add(0);
            int totals = 0;
            foreach(var query in queriesForCount)
            {
                int count = (int) _repository.ExecWithSqlQuery(query).Rows[0]["totalCount"];
                counts.Add(count);
                totals += count;
                prefSum.Add(totals);
            }

            var results = new QueryResultDto();
            for(int i =0; i<queries.Count();i++)
            {
                // TODO: Need to determine how many data to get from a particular table
                // 
                List<int> indexes = getPaginationData(counts, totals, prefSum, request.Query.PageSize, request.Query.PageIndex,i);

                if (indexes[0] < 0 || indexes[1] < 0 || (indexes[1] - indexes[0])<=0)
                {
                    continue;
                }

                string query = queries[i] + $",@startIndex={indexes[0]},@Limit={indexes[1] - indexes[0]},@secondLevel={branchId[0]},@thirdLevel={branchId[1]},@fourthLevel={branchId[2]}";

                var queryResult = _repository.ExecWithSqlQuery(query);
                List<Dictionary<string, object>> rows = queryResult.AsEnumerable()
                    .Select(row => queryResult.Columns.Cast<DataColumn>()
                    .ToDictionary(col => col.ColumnName, col => row[col]))
                    .ToList();

                results.Results.AddRange(rows);

            }

            results.Query = request.Query.keyword;
            results.ResponseCount = results.Results.Count;
            results.TotalResult = totals;

            return results;
        }

        List<string> GetQueriesForCount(List<string> filters, string keyword, List<string> branchId)
        {
            string traineeCountQuery = $"EXEC [dbo].[spTraineeSearchCount] @query='{keyword}',@secondLevel={branchId[0]},@thirdLevel={branchId[1]},@fourthLevel={branchId[2]}";
            string instructorCountQuery = $"EXEC [dbo].[spInstructorSearchCount] @query='{keyword}',@secondLevel={branchId[0]},@thirdLevel={branchId[1]},@fourthLevel={branchId[2]}";
            string courseCountQuery = $"EXEC [dbo].[spCourseSearchCount] @query='{keyword}',@secondLevel={branchId[0]},@thirdLevel={branchId[1]},@fourthLevel={branchId[2]}";

            bool needTrainee = filters.Where(x => x == "trainee").Any()||filters.Count()==0;
            bool needInstructor = filters.Where(x => x == "instructor").Any()||filters.Count()==0;
            bool needCourse = filters.Where(x => x == "course").Any() || filters.Count()==0;

            List<string> queriesForCount = new List<string>();

            // add which sp need to execute for counting the total result according to the filters
            if (needTrainee)
            {
                queriesForCount.Add(traineeCountQuery);
            }

            if (needInstructor)
            {
                queriesForCount.Add(instructorCountQuery);
            }

            if (needCourse)
            {
                queriesForCount.Add(courseCountQuery);
            }

            return queriesForCount;
        }

        List<string> GetQueriesForResult(List<string> filters, string keyword)
        {
            string traineeQuery = $"EXEC [dbo].[spTraineeSearch] @query='{keyword}'";
            string instructorQuery = $"EXEC [dbo].[spInstructorSearch] @query='{keyword}'";
            string courseQuery = $"EXEC [dbo].[spCourseSearch] @query='{keyword}'";

            bool needTrainee = filters.Where(x => x == "trainee").Any() || filters.Count() == 0;
            bool needInstructor = filters.Where(x => x == "instructor").Any() || filters.Count() == 0;
            bool needCourse = filters.Where(x => x == "course").Any() || filters.Count() == 0;

            List<string> QueriesForResult = new List<string>();

            if (needTrainee)
            {
                QueriesForResult.Add(traineeQuery);
            }

            if (needInstructor)
            {
                QueriesForResult.Add(instructorQuery);
            }

            if (needCourse)
            {
                QueriesForResult.Add(courseQuery);
            }

            return QueriesForResult;
        }

        List<int> getPaginationData(List<int> counts, int totalCounts, List<int> prefSum, int pageSize, int pageIndex, int tableIndex)
        {
            List<int> indexes = new List<int>();
            List<int> result = new List<int>();
            int start = Math.Max(0, pageIndex - 1) * pageSize;
            int end = Math.Min(pageSize * pageIndex,totalCounts);

            if((totalCounts+pageSize-1)/pageSize<pageIndex)
            {
                result.Add(-1);
                result.Add(-1);
                return result;
            }

            int curStartTable = -1;
            int curStartIndex = -1;
            int curEndIndex = -1;
            int curEndTable = -1;
            int startIndex = -1;
            int endIndex = -1;

            

            for(int i = 0; i < prefSum.Count()-1; i++)
            {
                if (prefSum[i+1] >=start)
                {
                    curStartIndex = start - prefSum[i];
                    curStartTable = i;
                    break;

                }
            }

            for(int i = 0; i<prefSum.Count()-1; i++)
            {
                if (prefSum[i+1]>=end)
                {
                    curEndIndex = end - prefSum[i];
                    curEndTable = i;
                    break;
                }
            }



            if(tableIndex>curStartTable&&tableIndex<=curEndTable)
            {
                startIndex = 0;
            } else if(tableIndex == curStartTable)
            {
                startIndex = curStartIndex;
            }

            if(tableIndex < curEndTable)
            {
                endIndex = counts[tableIndex];
            } else if(tableIndex == curEndTable)
            {
                endIndex = curEndIndex;
            }

            
            result.Add(startIndex);
            result.Add(endIndex);
            return result;

        }
    }
}
