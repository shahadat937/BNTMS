using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PaymentType;
using SchoolManagement.Application.Features.PaymentTypes.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PaymentTypes.Handlers.Queries
{
    public class GetPaymentTypeDetailRequestHandler : IRequestHandler<GetPaymentTypeDetailRequest, PaymentTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.PaymentType> _PaymentTypeRepository;
        public GetPaymentTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.PaymentType> PaymentTypeRepository, IMapper mapper)
        {
            _PaymentTypeRepository = PaymentTypeRepository;
            _mapper = mapper;
        }
        public async Task<PaymentTypeDto> Handle(GetPaymentTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var PaymentType = await _PaymentTypeRepository.Get(request.PaymentTypeId);
            return _mapper.Map<PaymentTypeDto>(PaymentType);
        }
    }
}
