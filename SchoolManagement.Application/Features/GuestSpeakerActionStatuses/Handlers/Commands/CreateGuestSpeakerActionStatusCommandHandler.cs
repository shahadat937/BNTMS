using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GuestSpeakerActionStatus.Validators;
using SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Handlers.Commands
{
    public class CreateGuestSpeakerActionStatusCommandHandler : IRequestHandler<CreateGuestSpeakerActionStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGuestSpeakerActionStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGuestSpeakerActionStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateGuestSpeakerActionStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GuestSpeakerActionStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var GuestSpeakerActionStatus = _mapper.Map<GuestSpeakerActionStatus>(request.GuestSpeakerActionStatusDto);

                GuestSpeakerActionStatus = await _unitOfWork.Repository<GuestSpeakerActionStatus>().Add(GuestSpeakerActionStatus);

                //await _unitOfWork.Save();
                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = GuestSpeakerActionStatus.GuestSpeakerActionStatusId;
            }

            return response;
        }
    }
}
