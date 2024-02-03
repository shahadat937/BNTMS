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
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.BnaPromotionStatuses.Handlers.Commands
{
    public class CreateBnaPromotionStatusCommandHandler : IRequestHandler<CreateBnaPromotionStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaPromotionStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaPromotionStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaPromotionStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaPromotionStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaPromotionStatus = _mapper.Map<BnaPromotionStatus>(request.BnaPromotionStatusDto);

                BnaPromotionStatus = await _unitOfWork.Repository<BnaPromotionStatus>().Add(BnaPromotionStatus);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaPromotionStatus.BnaPromotionStatusId;
            }

            return response;
        }
    }
}
