using AutoMapper;
using SchoolManagement.Application.DTOs.BnaPromotionStatus.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR; 
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaPromotionStatuses.Handlers.Commands
{
    public class UpdateBnaPromotionStatusCommandHandler : IRequestHandler<UpdateBnaPromotionStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaPromotionStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaPromotionStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaPromotionStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaPromotionStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaPromotionStatus = await _unitOfWork.Repository<BnaPromotionStatus>().Get(request.BnaPromotionStatusDto.BnaPromotionStatusId);

            if (BnaPromotionStatus is null)
                throw new NotFoundException(nameof(BnaPromotionStatus), request.BnaPromotionStatusDto.BnaPromotionStatusId);

            _mapper.Map(request.BnaPromotionStatusDto, BnaPromotionStatus);

            await _unitOfWork.Repository<BnaPromotionStatus>().Update(BnaPromotionStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
