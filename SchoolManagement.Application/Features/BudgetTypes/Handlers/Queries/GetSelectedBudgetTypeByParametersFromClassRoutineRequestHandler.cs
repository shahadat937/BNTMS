using MediatR;
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
    public class GetSelectedBudgetTypeByParametersFromClassRoutineRequestHandler : IRequestHandler<GetSelectedBudgetTypeByParametersFromClassRoutineRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

           
        public GetSelectedBudgetTypeByParametersFromClassRoutineRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBudgetTypeByParametersFromClassRoutineRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> classRoutines = _classRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId, "BudgetType"); 
            List<SelectedModel> selectModels = classRoutines.Select(x => new SelectedModel 
            {
                //Text = x.BudgetType.BudgetTypeName,
                //Value = x.BudgetTypeId 
            }).Distinct().ToList();
            return selectModels;
        }
    }
}

