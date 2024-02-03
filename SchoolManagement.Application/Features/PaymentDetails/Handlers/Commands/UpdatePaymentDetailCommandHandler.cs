using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PaymentDetail.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PaymentDetails.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PaymentDetails.Handler.Commands
{
    public class UpdatePaymentDetailCommandHandler : IRequestHandler<UpdatePaymentDetailCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;
         
        public UpdatePaymentDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePaymentDetailCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePaymentDetailDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.PaymentDetailDto); 

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 

            var PaymentDetail = await _unitOfWork.Repository<PaymentDetail>().Get(request.PaymentDetailDto.PaymentDetailId);

            if (PaymentDetail is null)
                throw new NotFoundException(nameof(PaymentDetail), request.PaymentDetailDto.PaymentDetailId); 

            _mapper.Map(request.PaymentDetailDto, PaymentDetail); 

            await _unitOfWork.Repository<PaymentDetail>().Update(PaymentDetail);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}