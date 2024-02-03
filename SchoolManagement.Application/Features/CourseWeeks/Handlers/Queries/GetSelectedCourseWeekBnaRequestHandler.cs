using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Data;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Queries
{
    public class GetSelectedCourseWeekBnaRequestHandler : IRequestHandler<GetSelectedCourseWeekBnaRequest, object>
    {
        private readonly ISchoolManagementRepository<CourseWeek> _CourseWeekRepository;


        public GetSelectedCourseWeekBnaRequestHandler(ISchoolManagementRepository<CourseWeek> CourseWeekRepository)
        {
            _CourseWeekRepository = CourseWeekRepository;
        }
       // BnaSemesterDuration  ,BnaSemester

        public async Task<object> Handle(GetSelectedCourseWeekBnaRequest request, CancellationToken cancellationToken)
        {

            /*  ICollection<CourseWeek> codeValues = await _CourseWeekRepository.FilterAsync(x =>
                      x.BaseSchoolNameId == request.BaseSchoolNameId 
                      && x.CourseDurationId == request.CourseDurationId 
                      && x.BnaSemesterId == request.BnaSemesterId 
                      && x.CourseNameId == request.CourseNameId 
                      && x.Status == (request.Status == 100 ? x.Status : 0));

               List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
              {
                      Text = x.WeekName,
                      Value = x.CourseWeekId
              }).ToList();
            */
               var spQuery = String.Format("exec [spGetCourseWeekBna] {0},{1}", request.BnaSemesterId, request.CourseDurationId);

             DataTable dataTable = _CourseWeekRepository.ExecWithSqlQuery(spQuery);




            return dataTable;
            
        }
    }
}
