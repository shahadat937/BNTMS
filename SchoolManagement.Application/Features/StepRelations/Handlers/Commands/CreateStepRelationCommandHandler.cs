using AutoMapper;
using SchoolManagement.Application.DTOs.StepRelation.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.StepRelations.Requests.Commands;
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

namespace SchoolManagement.Application.Features.StepRelations.Handlers.Commands
{
    public class CreateStepRelationCommandHandler : IRequestHandler<CreateStepRelationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateStepRelationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateStepRelationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateStepRelationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.StepRelationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var StepRelation = _mapper.Map<StepRelation>(request.StepRelationDto);

                StepRelation = await _unitOfWork.Repository<StepRelation>().Add(StepRelation);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = StepRelation.StepRelationId;
            }

            return response;
        }
    }
}
