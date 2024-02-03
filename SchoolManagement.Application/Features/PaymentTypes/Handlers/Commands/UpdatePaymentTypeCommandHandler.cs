using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.PaymentType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.PaymentTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.PaymentTypes.Handlers.Commands
{
    public class UpdatePaymentTypeCommandHandler : IRequestHandler<UpdatePaymentTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePaymentTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePaymentTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePaymentTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.PaymentTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var PaymentType = await _unitOfWork.Repository<PaymentType>().Get(request.PaymentTypeDto.PaymentTypeId);

            if (PaymentType is null)
                throw new NotFoundException(nameof(PaymentType), request.PaymentTypeDto.PaymentTypeId);

            _mapper.Map(request.PaymentTypeDto, PaymentType);

            await _unitOfWork.Repository<PaymentType>().Update(PaymentType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
