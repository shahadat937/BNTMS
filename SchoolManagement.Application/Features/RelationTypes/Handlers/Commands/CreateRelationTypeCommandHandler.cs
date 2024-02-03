using AutoMapper;
using SchoolManagement.Application.DTOs.RelationType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RelationTypes.Requests.Commands;
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

namespace SchoolManagement.Application.Features.RelationTypes.Handlers.Commands
{
    public class CreateRelationTypeCommandHandler : IRequestHandler<CreateRelationTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRelationTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateRelationTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateRelationTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.RelationTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var RelationType = _mapper.Map<RelationType>(request.RelationTypeDto);

                RelationType = await _unitOfWork.Repository<RelationType>().Add(RelationType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = RelationType.RelationTypeId;
            }

            return response;
        }
    }
}
