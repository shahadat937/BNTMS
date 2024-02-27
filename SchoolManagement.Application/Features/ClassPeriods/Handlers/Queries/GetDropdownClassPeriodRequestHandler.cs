using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BNASubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries
{
    public class GetDropdownClassPeriodRequestHandler : IRequestHandler<GetDropdownClassPeriodRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ClassPeriod> _ClassPeriodRepository;


        public GetDropdownClassPeriodRequestHandler(ISchoolManagementRepository<ClassPeriod> ClassPeriodRepository)
        {
            _ClassPeriodRepository = ClassPeriodRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetDropdownClassPeriodRequest request, CancellationToken cancellationToken)
        {
            ICollection<ClassPeriod> BnaSubjectNames = _ClassPeriodRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId).ToList();
            List<SelectedModel> selectModels = BnaSubjectNames.Select(x => new SelectedModel
            {
                Text = x.PeriodName,
                Value = x.ClassPeriodId
            }).ToList();
            return selectModels;
        }
    }
}
