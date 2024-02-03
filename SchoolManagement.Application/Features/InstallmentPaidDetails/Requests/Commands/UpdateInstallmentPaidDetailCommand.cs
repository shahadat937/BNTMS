using MediatR;
using SchoolManagement.Application.DTOs.InstallmentPaidDetail;

namespace SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Commands
{
    public class UpdateInstallmentPaidDetailCommand : IRequest<Unit> 
    { 
        public InstallmentPaidDetailDto InstallmentPaidDetailDto { get; set; }   
    }
}
