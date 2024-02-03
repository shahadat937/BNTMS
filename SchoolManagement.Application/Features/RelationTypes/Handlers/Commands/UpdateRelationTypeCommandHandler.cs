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

namespace SchoolManagement.Application.Features.RelationTypes.Handlers.Commands
{
    public class UpdateRelationTypeCommandHandler : IRequestHandler<UpdateRelationTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRelationTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRelationTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRelationTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.RelationTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var RelationType = await _unitOfWork.Repository<RelationType>().Get(request.RelationTypeDto.RelationTypeId);

            if (RelationType is null)
                throw new NotFoundException(nameof(RelationType), request.RelationTypeDto.RelationTypeId);

            _mapper.Map(request.RelationTypeDto, RelationType);

            await _unitOfWork.Repository<RelationType>().Update(RelationType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
