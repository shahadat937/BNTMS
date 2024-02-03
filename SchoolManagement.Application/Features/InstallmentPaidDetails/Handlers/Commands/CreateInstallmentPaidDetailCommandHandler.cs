using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InstallmentPaidDetail.Validators;
using SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InstallmentPaidDetails.Handler.Commands
{
    public class CreateInstallmentPaidDetailCommandHandler : IRequestHandler<CreateInstallmentPaidDetailCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
          
        public CreateInstallmentPaidDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<BaseCommandResponse> Handle(CreateInstallmentPaidDetailCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateInstallmentPaidDetailDtoValidator();
            var validationResult = await validator.ValidateAsync(request.InstallmentPaidDetailDto); 

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var InstallmentPaidDetail = _mapper.Map<InstallmentPaidDetail>(request.InstallmentPaidDetailDto);
                InstallmentPaidDetail.PaymentCompletedStatus = 0;
                InstallmentPaidDetail.ScheduleDate = InstallmentPaidDetail.ScheduleDate.Value.AddDays(1.0);
                InstallmentPaidDetail = await _unitOfWork.Repository<InstallmentPaidDetail>().Add(InstallmentPaidDetail);
               
                    await _unitOfWork.Save();
               
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = InstallmentPaidDetail.InstallmentPaidDetailId;
            }

            return response;
        }
    }
}
