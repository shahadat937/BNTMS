using AutoMapper;
using SchoolManagement.Application.DTOs.CovidVaccine.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CovidVaccines.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CovidVaccines.Handlers.Commands
{
    public class UpdateCovidVaccineCommandHandler : IRequestHandler<UpdateCovidVaccineCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCovidVaccineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCovidVaccineCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCovidVaccineDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CovidVaccineDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CovidVaccine = await _unitOfWork.Repository<CovidVaccine>().Get(request.CovidVaccineDto.CovidVaccineId);

            if (CovidVaccine is null)
                throw new NotFoundException(nameof(CovidVaccine), request.CovidVaccineDto.CovidVaccineId);

            _mapper.Map(request.CovidVaccineDto, CovidVaccine);

            await _unitOfWork.Repository<CovidVaccine>().Update(CovidVaccine);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
