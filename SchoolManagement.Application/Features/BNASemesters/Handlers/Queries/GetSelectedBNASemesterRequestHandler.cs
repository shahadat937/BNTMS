using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSemesters.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSemesters.Handlers.Queries
{ 
    public class GetSelectedBnaSemesterRequestHandler : IRequestHandler<GetSelectedBnaSemesterRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaSemester> _BnaSemesterRepository;


        public GetSelectedBnaSemesterRequestHandler(ISchoolManagementRepository<BnaSemester> BnaSemesterRepository)
        {
            _BnaSemesterRepository = BnaSemesterRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaSemesterRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaSemester> bnaSemesters = await _BnaSemesterRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = bnaSemesters.Select(x => new SelectedModel 
            {
                Text = x.SemesterName,
                Value = x.BnaSemesterId
            }).ToList();
            return selectModels;
        }
    }
}
