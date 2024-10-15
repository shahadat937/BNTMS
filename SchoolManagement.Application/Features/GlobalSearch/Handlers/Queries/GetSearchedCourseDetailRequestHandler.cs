using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GlobalSearch;
using SchoolManagement.Application.Features.GlobalSearch.Requests.Queries;
using SchoolManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Application.Features.GlobalSearch.Handlers.Queries
{
    public class GetSearchedCourseDetailRequestHandler: IRequestHandler<GetSearchedCourseDetailRequest, object>
    {
        private readonly ISchoolManagementRepository<Domain.TraineeNomination> _TraineeNominationRepo;
        private readonly ISchoolManagementRepository<Domain.CourseInstructor> _CourseInstructorRepo;
        private readonly ISchoolManagementRepository<Domain.TraineeBioDataGeneralInfo> _TraineeBioDataRepo;
        private readonly ISchoolManagementRepository<Domain.BnaSubjectName> _BnaSubjectRepo;
        private readonly ISchoolManagementRepository<Domain.CourseDuration> _CourseDurationRepo;

        public GetSearchedCourseDetailRequestHandler(ISchoolManagementRepository<Domain.CourseInstructor> CourseInstructorRepo, ISchoolManagementRepository<Domain.TraineeBioDataGeneralInfo> TraineeBioDataRepo, ISchoolManagementRepository<Domain.BnaSubjectName> bnaSubjectRepo, 
          ISchoolManagementRepository<Domain.CourseDuration> CourseDurationRepo, 
          ISchoolManagementRepository<Domain.TraineeNomination> TraineeNominationRepo)
        {
            _CourseInstructorRepo = CourseInstructorRepo;
            _TraineeBioDataRepo = TraineeBioDataRepo;
            _BnaSubjectRepo = bnaSubjectRepo;
            _CourseDurationRepo = CourseDurationRepo;
            _TraineeNominationRepo = TraineeNominationRepo;
        }

        public async Task<object> Handle(GetSearchedCourseDetailRequest request, CancellationToken cancellationToken)
        {
            //TODO: Need to get total trainee,instructor,total subject, and time duration of courses

            // 
            var courseDuration = await _CourseDurationRepo.Get(request.CourseDurationId);
            if(courseDuration == null)
            {
                throw new NotFoundException(nameof(courseDuration), request.CourseDurationId);
            }


            string totalInstructorQuery = $"EXEC [dbo].[spGetInstructorCountByCourse] @CourseDurationId={request.CourseDurationId}, @BaseSchoolNameId={courseDuration.BaseSchoolNameId}, @CourseNameId={courseDuration.CourseNameId}";


            var summary = new CourseSummaryDto();
            summary.TotalSubject = await _BnaSubjectRepo.Where(x => x.CourseNameId == courseDuration.CourseNameId && x.BaseSchoolNameId == courseDuration.BaseSchoolNameId).CountAsync();
            summary.TotalTrainee = await _TraineeNominationRepo.Where(x => x.CourseDurationId == request.CourseDurationId).CountAsync();
            //summary.TotalInstructor = await _CourseInstructorRepo.Where(x => x.CourseDurationId == request.CourseDurationId && x.BaseSchoolNameId == courseDuration.BaseSchoolNameId).Select(x => x.TraineeId).Distinct().CountAsync();
            summary.TotalInstructor = (int)_CourseDurationRepo.ExecWithSqlQuery(totalInstructorQuery).Rows[0]["TotalInstructor"];

            return summary;
        }
    }
}
