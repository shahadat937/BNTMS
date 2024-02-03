using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.TdecQuationGroup.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TdecQuationGroups.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Handlers.Commands
{
    public class UpdateTdecQuationGroupCommandHandler : IRequestHandler<UpdateTdecQuationGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTdecQuationGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTdecQuationGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTdecQuationGroupDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.TdecQuationGroupDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TdecQuationGroup = await _unitOfWork.Repository<TdecQuationGroup>().Get(request.TdecQuationGroupDto.TdecQuationGroupId);

            if (TdecQuationGroup is null)
                throw new NotFoundException(nameof(TdecQuationGroup), request.TdecQuationGroupDto.TdecQuationGroupId);

            _mapper.Map(request.TdecQuationGroupDto, TdecQuationGroup);

            await _unitOfWork.Repository<TdecQuationGroup>().Update(TdecQuationGroup);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
