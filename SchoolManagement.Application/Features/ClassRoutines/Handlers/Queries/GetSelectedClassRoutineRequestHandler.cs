using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetSelectedClassRoutineRequestHandler : IRequestHandler<GetSelectedClassRoutineRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _ClassRoutineRepository;


        public GetSelectedClassRoutineRequestHandler(ISchoolManagementRepository<ClassRoutine> ClassRoutineRepository)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedClassRoutineRequest request, CancellationToken cancellationToken)
        {
            ICollection<ClassRoutine> codeValues = await _ClassRoutineRepository.FilterAsync(x => x.IsActive); 
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Date,
                Value = x.ClassRoutineId
            }).ToList();
            return selectModels;
        }
    }
}
