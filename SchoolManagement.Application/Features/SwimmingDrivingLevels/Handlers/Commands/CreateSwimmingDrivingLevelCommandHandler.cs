using AutoMapper;
using SchoolManagement.Application.DTOs.SwimmingDrivingLevel.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests.Commands;
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

namespace SchoolManagement.Application.Features.SwimmingDrivingLevels.Handlers.Commands
{
    public class CreateSwimmingDrivingLevelCommandHandler : IRequestHandler<CreateSwimmingDrivingLevelCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSwimmingDrivingLevelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSwimmingDrivingLevelCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSwimmingDrivingLevelDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SwimmingDrivingLevelDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SwimmingDrivingLevels = _mapper.Map<SwimmingDrivingLevel>(request.SwimmingDrivingLevelDto);

                SwimmingDrivingLevels = await _unitOfWork.Repository<SwimmingDrivingLevel>().Add(SwimmingDrivingLevels);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SwimmingDrivingLevels.SwimmingDrivingLevelId;
            }

            return response;
        }
    }
}
