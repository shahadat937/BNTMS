using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InstallmentPaidDetail.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InstallmentPaidDetails.Handler.Commands
{
    public class UpdateInstallmentPaidDetailCommandHandler : IRequestHandler<UpdateInstallmentPaidDetailCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;
         
        public UpdateInstallmentPaidDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateInstallmentPaidDetailCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInstallmentPaidDetailDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.InstallmentPaidDetailDto); 

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 

            var InstallmentPaidDetail = await _unitOfWork.Repository<InstallmentPaidDetail>().Get(request.InstallmentPaidDetailDto.InstallmentPaidDetailId);

            if (InstallmentPaidDetail is null)
                throw new NotFoundException(nameof(InstallmentPaidDetail), request.InstallmentPaidDetailDto.InstallmentPaidDetailId); 

            _mapper.Map(request.InstallmentPaidDetailDto, InstallmentPaidDetail); 

            await _unitOfWork.Repository<InstallmentPaidDetail>().Update(InstallmentPaidDetail);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}