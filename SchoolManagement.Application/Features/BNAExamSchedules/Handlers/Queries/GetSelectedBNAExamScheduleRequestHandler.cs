using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaExamSchedules.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaExamSchedules.Handlers.Queries

{
    public class GetSelectedBnaExamScheduleRequestHandler : IRequestHandler<GetSelectedBnaExamScheduleRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaExamSchedule> _BnaExamScheduleRepository;


        public GetSelectedBnaExamScheduleRequestHandler(ISchoolManagementRepository<BnaExamSchedule> BnaExamScheduleRepository)
        {
            _BnaExamScheduleRepository = BnaExamScheduleRepository;

        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaExamScheduleRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaExamSchedule> codeValues = await _BnaExamScheduleRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel

            {
                Text = x.ExamDate,
                Value = x.BnaExamScheduleId
            }).ToList();
            return selectModels;
        }
    }
}
