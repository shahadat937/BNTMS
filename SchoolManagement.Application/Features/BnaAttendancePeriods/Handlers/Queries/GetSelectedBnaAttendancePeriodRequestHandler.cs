using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.BnaAttendancePeriods.Handlers.Queries
{
    public class GetSelectedBnaAttendancePeriodRequestHandler : IRequestHandler<GetSelectedBnaAttendancePeriodRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaAttendancePeriod> _BnaAttendancePeriodRepository;


        public GetSelectedBnaAttendancePeriodRequestHandler(ISchoolManagementRepository<BnaAttendancePeriod> BnaAttendancePeriodRepository)
        {
            _BnaAttendancePeriodRepository = BnaAttendancePeriodRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaAttendancePeriodRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaAttendancePeriod> BnaAttendancePeriods = await _BnaAttendancePeriodRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = BnaAttendancePeriods.Select(x => new SelectedModel 
            {
                Text = x.PeriodName,
                Value = x.BnaAttendancePeriodId
            }).ToList();
            return selectModels;
        }
    }
}
