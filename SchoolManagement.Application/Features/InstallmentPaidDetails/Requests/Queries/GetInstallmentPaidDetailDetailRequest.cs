using MediatR;
using SchoolManagement.Application.DTOs.InstallmentPaidDetail;

namespace SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Queries
{
    public class GetInstallmentPaidDetailDetailRequest : IRequest<InstallmentPaidDetailDto>
    {
        public int Id { get; set; }
    }
}
