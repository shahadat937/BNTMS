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
    public class GetSelectedMarkTypeFromClassRoutineRequestHandler : IRequestHandler<GetSelectedMarkTypeFromClassRoutineRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _ClassRoutineRepository;

         
        public GetSelectedMarkTypeFromClassRoutineRequestHandler(ISchoolManagementRepository<ClassRoutine> ClassRoutineRepository)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
        }
         
        public async Task<List<SelectedModel>> Handle(GetSelectedMarkTypeFromClassRoutineRequest request, CancellationToken cancellationToken)
        {
            var codeValues = _ClassRoutineRepository.FilterWithInclude(x => x.IsActive && x.ClassRoutineId == request.ClassRoutineId ,"MarkType");
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.MarkType.ShortName,
                Value = x.ClassRoutineId
            }).ToList();
            return selectModels;
        }
    }
}
