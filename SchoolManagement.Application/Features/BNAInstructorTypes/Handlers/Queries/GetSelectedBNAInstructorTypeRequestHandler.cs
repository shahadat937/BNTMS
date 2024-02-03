using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaInstructorTypees.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaInstructorTypes.Handlers.Queries
{
    public class GetSelectedBnaInstructorTypeRequestHandler : IRequestHandler<GetSelectedBnaInstructorTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaInstructorType> _BnaInstructorTypeRepository;


        public GetSelectedBnaInstructorTypeRequestHandler(ISchoolManagementRepository<BnaInstructorType> BnaInstructorTypeRepository)
        {
            _BnaInstructorTypeRepository = BnaInstructorTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaInstructorTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaInstructorType> BnaInstructorType = await _BnaInstructorTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = BnaInstructorType.Select(x => new SelectedModel
            { 
                Text = x.InstructorTypeName, 
                Value = x.BnaInstructorTypeId
            }).ToList();
            return selectModels; 
        }
    }
}
