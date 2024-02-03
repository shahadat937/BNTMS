using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PaymentTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PaymentTypes.Handlers.Commands
{
    public class DeletePaymentTypeCommandHandler : IRequestHandler<DeletePaymentTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePaymentTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            var PaymentType = await _unitOfWork.Repository<PaymentType>().Get(request.PaymentTypeId);

            if (PaymentType == null)
                throw new NotFoundException(nameof(PaymentType), request.PaymentTypeId);

            await _unitOfWork.Repository<PaymentType>().Delete(PaymentType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
