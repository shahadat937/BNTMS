using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.WeekName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.WeekNames.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WeekNames.Handlers.Commands
{
    public class UpdateWeekNameCommandHandler : IRequestHandler<UpdateWeekNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateWeekNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWeekNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateWeekNameDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.WeekNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var WeekName = await _unitOfWork.Repository<WeekName>().Get(request.WeekNameDto.WeekNameId);

            if (WeekName is null)
                throw new NotFoundException(nameof(WeekName), request.WeekNameDto.WeekNameId);

            _mapper.Map(request.WeekNameDto, WeekName);

            await _unitOfWork.Repository<WeekName>().Update(WeekName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
