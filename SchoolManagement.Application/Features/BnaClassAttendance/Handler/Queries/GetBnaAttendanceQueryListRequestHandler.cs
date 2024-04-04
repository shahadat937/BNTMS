using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaClassAttendance.Request.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassAttendance.Handler.Queries
{
    public class GetBnaAttendanceQueryListRequestHandler : IRequestHandler<GetBnaAttendanceQueryListRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseNomenee> _CourseNomeneeRepository;
        private readonly ISchoolManagementRepository<BnaClassRoutine> _BnaClassRoutineRepository;

        public GetBnaAttendanceQueryListRequestHandler(ISchoolManagementRepository<CourseNomenee> CourseNomeneeRepository, ISchoolManagementRepository<BnaClassRoutine> BnaClassRoutineRepository)
        {
            _CourseNomeneeRepository = CourseNomeneeRepository;
            _BnaClassRoutineRepository = BnaClassRoutineRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetBnaAttendanceQueryListRequest request, CancellationToken cancellationToken)
        {
            DateTime date = DateTime.ParseExact(request.Date, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);

            IQueryable<BnaClassRoutine> bnaClassRoutines = _BnaClassRoutineRepository.Where(x => x.Date == date);

            List<SelectedModel> selectModels = bnaClassRoutines.Select(x => new SelectedModel
            {
                Text = x.CourseSectionId,
                Value = x.ClassPeriodId
            }).ToList();

            return selectModels;
        }
    }
}
