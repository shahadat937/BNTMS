using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.InstallmentPaidDetails.Handlers.Commands
{
    public class ChangePaymentCompletedStatusCommandHandler : IRequestHandler<ChangePaymentCompletedStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public ChangePaymentCompletedStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ChangePaymentCompletedStatusCommand request, CancellationToken cancellationToken)
        {
            var InstallmentPaidDetail = await _unitOfWork.Repository<InstallmentPaidDetail>().Get(request.InstallmentPaidDetailId);
            InstallmentPaidDetail.PaymentCompletedStatus = request.PaymentCompletedStatus;

            if (InstallmentPaidDetail == null)
                throw new NotFoundException(nameof(InstallmentPaidDetail), request.InstallmentPaidDetailId);

            await _unitOfWork.Repository<InstallmentPaidDetail>().Update(InstallmentPaidDetail);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
