using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PaymentDetail.Validators;
using SchoolManagement.Application.Features.PaymentDetails.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PaymentDetails.Handler.Commands
{
    public class CreatePaymentDetailCommandHandler : IRequestHandler<CreatePaymentDetailCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
          
        public CreatePaymentDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<BaseCommandResponse> Handle(CreatePaymentDetailCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreatePaymentDetailDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PaymentDetailDto); 

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var PaymentDetail = _mapper.Map<PaymentDetail>(request.PaymentDetailDto); 

                PaymentDetail = await _unitOfWork.Repository<PaymentDetail>().Add(PaymentDetail);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = PaymentDetail.PaymentDetailId;
            }

            return response;
        }
    }
}
