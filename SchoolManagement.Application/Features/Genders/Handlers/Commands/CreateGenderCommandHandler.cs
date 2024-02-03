﻿using AutoMapper;
using SchoolManagement.Application.DTOs.Gender.Validators;
using SchoolManagement.Application.Features.Genders.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.Genders.Handlers.Commands
{
    public class CreateGenderCommandHandler : IRequestHandler<CreateGenderCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGenderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGenderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateGenderDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GenderDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Gender = _mapper.Map<Gender>(request.GenderDto);

                Gender = await _unitOfWork.Repository<Gender>().Add(Gender);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Gender.GenderId;
            }

            return response;
        }
    }
}
