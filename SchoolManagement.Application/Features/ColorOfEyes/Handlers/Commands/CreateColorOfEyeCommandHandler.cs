using AutoMapper;
using SchoolManagement.Application.DTOs.ColorOfEye.Validators;
using System.Collections.Generic;
using SchoolManagement.Application.Features.ColorOfEyes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;


namespace SchoolManagement.Application.Features.ColorOfEyes.Handlers.Commands
{
    public class CreateColorOfEyeCommandHandler : IRequestHandler<CreateColorOfEyeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateColorOfEyeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateColorOfEyeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateColorOfEyeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ColorOfEyeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ColorOfEye = _mapper.Map<ColorOfEye>(request.ColorOfEyeDto);

                ColorOfEye = await _unitOfWork.Repository<ColorOfEye>().Add(ColorOfEye);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ColorOfEye.ColorOfEyeId;
            }

            return response;
        }
    }
}
