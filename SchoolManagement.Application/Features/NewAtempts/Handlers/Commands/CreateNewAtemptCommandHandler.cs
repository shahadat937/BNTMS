using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NewAtempt.Validators;
using SchoolManagement.Application.Features.NewAtempts.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NewAtempts.Handlers.Commands
{
    public class CreateNewAtemptCommandHandler : IRequestHandler<CreateNewAtemptCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateNewAtemptCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateNewAtemptCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateNewAtemptDtoValidator();
            var validationResult = await validator.ValidateAsync(request.NewAtemptDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var NewAtempt = _mapper.Map<NewAtempt>(request.NewAtemptDto);

                NewAtempt = await _unitOfWork.Repository<NewAtempt>().Add(NewAtempt);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = NewAtempt.NewAtemptId;
            }

            return response;
        }
    }
}
