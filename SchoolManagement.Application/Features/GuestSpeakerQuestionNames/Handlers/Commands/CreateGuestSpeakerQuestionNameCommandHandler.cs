using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName.Validators;
using SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Handlers.Commands
{
    public class CreateGuestSpeakerQuestionNameCommandHandler : IRequestHandler<CreateGuestSpeakerQuestionNameCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGuestSpeakerQuestionNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGuestSpeakerQuestionNameCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateGuestSpeakerQuestionNameDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GuestSpeakerQuestionNameDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var GuestSpeakerQuestionName = _mapper.Map<GuestSpeakerQuestionName>(request.GuestSpeakerQuestionNameDto);

                GuestSpeakerQuestionName = await _unitOfWork.Repository<GuestSpeakerQuestionName>().Add(GuestSpeakerQuestionName);
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
                response.Id = GuestSpeakerQuestionName.GuestSpeakerQuestionNameId;
            }

            return response;
        }
    }
}
