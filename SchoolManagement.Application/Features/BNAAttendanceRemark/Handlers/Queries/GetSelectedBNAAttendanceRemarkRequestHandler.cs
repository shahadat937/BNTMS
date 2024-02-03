using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks; 

namespace SchoolManagement.Application.Features.BnaAttendanceRemark.Handlers.Queries
{
    public class GetSelectedBnaAttendanceRemarkRequestHandler : IRequestHandler<GetSelectedBnaAttendanceRemarkRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaAttendanceRemarks> _BnaAttendanceRemarkRepository;


        public GetSelectedBnaAttendanceRemarkRequestHandler(ISchoolManagementRepository<BnaAttendanceRemarks> BnaAttendanceRemarkRepository)
        {
            _BnaAttendanceRemarkRepository = BnaAttendanceRemarkRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaAttendanceRemarkRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaAttendanceRemarks> codeValues = await _BnaAttendanceRemarkRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.AttendanceRemarksCause,
                Value = x.BnaAttendanceRemarksId 
            }).ToList();
            return selectModels;
        }
    }
}
