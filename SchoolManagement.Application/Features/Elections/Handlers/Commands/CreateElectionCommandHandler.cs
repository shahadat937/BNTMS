using AutoMapper;
using SchoolManagement.Application.DTOs.Election.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Elections.Requests.Commands;
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

namespace SchoolManagement.Application.Features.Elections.Handlers.Commands
{
    public class CreateElectionCommandHandler : IRequestHandler<CreateElectionCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateElectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateElectionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateElectionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ElectionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Election = _mapper.Map<Election>(request.ElectionDto);

                Election = await _unitOfWork.Repository<Election>().Add(Election);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Election.ElectionId;
            }

            return response;
        }
    }
}
