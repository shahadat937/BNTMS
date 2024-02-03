using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.CountryGroup.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.CountryGroups.Requests.Commands;

namespace SchoolManagement.Application.Features.CountryGroups.Handlers.Commands
{
    public class UpdateCountryGroupCommandHandler : IRequestHandler<UpdateCountryGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCountryGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCountryGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCountryGroupDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CountryGroupDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CountryGroup = await _unitOfWork.Repository<CountryGroup>().Get(request.CountryGroupDto.CountryGroupId);

            if (CountryGroup is null)
                throw new NotFoundException(nameof(CountryGroup), request.CountryGroupDto.CountryGroupId);

            _mapper.Map(request.CountryGroupDto, CountryGroup);

            await _unitOfWork.Repository<CountryGroup>().Update(CountryGroup);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
