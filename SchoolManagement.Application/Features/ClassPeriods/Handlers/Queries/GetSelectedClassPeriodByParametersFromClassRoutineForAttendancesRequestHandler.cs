using MediatR;
using SchoolManagement.Application.Constants;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries    
{
    public class GetSelectedClassPeriodByParametersFromClassRoutineForAttendancesRequestHandler : IRequestHandler<GetSelectedClassPeriodByParametersFromClassRoutineForAttendancesRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

           
        public GetSelectedClassPeriodByParametersFromClassRoutineForAttendancesRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedClassPeriodByParametersFromClassRoutineForAttendancesRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> classRoutines = _classRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && (!x.Date.HasValue || x.Date.Value.Date == request.Date ), "ClassPeriod").Where(x=>x.AttendanceComplete== CompleteStatus.Completed); 
            List<SelectedModel> selectModels = classRoutines.Select(x => new SelectedModel 
            {
                Text = x.ClassPeriod.PeriodName,
                Value = x.ClassPeriodId 
            }).ToList();
            return selectModels;
        }
    }
}
