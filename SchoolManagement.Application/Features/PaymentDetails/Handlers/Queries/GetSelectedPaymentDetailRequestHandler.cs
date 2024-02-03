using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.PaymentDetails.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.PaymentDetails.Handlers.Queries
{
    public class GetSelectedPaymentDetailRequestHandler : IRequestHandler<GetSelectedPaymentDetailRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<PaymentDetail> _PaymentDetailRepository;


        public GetSelectedPaymentDetailRequestHandler(ISchoolManagementRepository<PaymentDetail> PaymentDetailRepository)
        {
            _PaymentDetailRepository = PaymentDetailRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPaymentDetailRequest request, CancellationToken cancellationToken)
        {
            ICollection<PaymentDetail> PaymentDetails = await _PaymentDetailRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = PaymentDetails.Select(x => new SelectedModel 
            {
                Text = x.NumberOfInstallment,
                Value = x.PaymentDetailId
            }).ToList();
            return selectModels;
        }
    }
}
