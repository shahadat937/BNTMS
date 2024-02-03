using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PaymentDetails.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PaymentDetails.Handler.Commands
{
    public class DeletePaymentDetailCommandHandler : IRequestHandler<DeletePaymentDetailCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public DeletePaymentDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePaymentDetailCommand request, CancellationToken cancellationToken)
        {
            var PaymentDetail = await _unitOfWork.Repository<PaymentDetail>().Get(request.Id);
             
            if (PaymentDetail == null)
                throw new NotFoundException(nameof(PaymentDetail), request.Id);

            await _unitOfWork.Repository<PaymentDetail>().Delete(PaymentDetail); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}