using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.BudgetCodess.Requests.Queries;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetCodess.Handlers.Queries   
{
    public class GetSelectedBudgetCodeByParametersFromClassRoutineRequestHandler : IRequestHandler<GetSelectedBudgetCodeByParametersFromClassRoutineRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;

           
        public GetSelectedBudgetCodeByParametersFromClassRoutineRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository)
        {
            _classRoutineRepository = classRoutineRepository;    
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBudgetCodeByParametersFromClassRoutineRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> classRoutines = _classRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId, "BudgetCode"); 
            List<SelectedModel> selectModels = classRoutines.Select(x => new SelectedModel 
            {
                //Text = x.BudgetCode.BudgetCodeName,
                //Value = x.BudgetCodeId 
            }).Distinct().ToList();
            return selectModels;
        }
    }
}

