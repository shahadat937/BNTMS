using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CurriculamTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaCurriculamTypes.Handlers.Queries
{
    public class GetSelectedBnaCurriculamTypeRequestHandler : IRequestHandler<GetSelectedBnaCurriculamTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaCurriculumType> _BnaCurriculamTypeRepository;


        public GetSelectedBnaCurriculamTypeRequestHandler(ISchoolManagementRepository<BnaCurriculumType> BnaCurriculamTypeRepository)
        {
            _BnaCurriculamTypeRepository = BnaCurriculamTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaCurriculamTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaCurriculumType> bnaCurriculamTypes = await _BnaCurriculamTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = bnaCurriculamTypes.Select(x => new SelectedModel 
            {
                Text = x.CurriculumType,
                Value = x.BnaCurriculumTypeId
            }).ToList();
            return selectModels;
        }
    }
}
