using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PaymentDetail;
using SchoolManagement.Application.Features.PaymentDetails.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PaymentDetails.Handler.Queries
{
    public class GetPaymentDetailDetailRequestHandler : IRequestHandler<GetPaymentDetailDetailRequest, PaymentDetailDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<PaymentDetail> _PaymentDetailRepository;     
        public GetPaymentDetailDetailRequestHandler(ISchoolManagementRepository<PaymentDetail> PaymentDetailRepository, IMapper mapper)
        {
            _PaymentDetailRepository = PaymentDetailRepository;  
            _mapper = mapper; 
        }
        public async Task<PaymentDetailDto> Handle(GetPaymentDetailDetailRequest request, CancellationToken cancellationToken)
        {
            var PaymentDetail = await _PaymentDetailRepository.Get(request.Id);   
            return _mapper.Map<PaymentDetailDto>(PaymentDetail);  
        }
    }
}
