using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.BNASubjectNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BNASubjectNames.Handlers.Queries
{

    public class GetDropdownSubjectNameRequestHandler : IRequestHandler<GetDropdownSubjectNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;


        public GetDropdownSubjectNameRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetDropdownSubjectNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaSubjectName> BnaSubjectNames = _BnaSubjectNameRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.SubjectActiveStatus != 0).ToList();
            List<SelectedModel> selectModels = BnaSubjectNames.Select(x => new SelectedModel
            {
                Text = x.SubjectName,
                Value = x.BnaSubjectNameId
            }).ToList();
            return selectModels;
        }
    }
}
