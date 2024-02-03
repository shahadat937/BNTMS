using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.TdecQuestionName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TdecQuestionNames.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecQuestionNames.Handlers.Commands
{
    public class UpdateTdecQuestionNameCommandHandler : IRequestHandler<UpdateTdecQuestionNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTdecQuestionNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTdecQuestionNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTdecQuestionNameDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.TdecQuestionNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TdecQuestionName = await _unitOfWork.Repository<TdecQuestionName>().Get(request.TdecQuestionNameDto.TdecQuestionNameId);

            if (TdecQuestionName is null)
                throw new NotFoundException(nameof(TdecQuestionName), request.TdecQuestionNameDto.TdecQuestionNameId);

            _mapper.Map(request.TdecQuestionNameDto, TdecQuestionName);

            await _unitOfWork.Repository<TdecQuestionName>().Update(TdecQuestionName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
