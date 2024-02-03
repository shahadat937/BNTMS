using AutoMapper;
using SchoolManagement.Application.DTOs.CovidVaccine.Validators;
using SchoolManagement.Application.Exceptions;
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
using SchoolManagement.Application.Features.CovidVaccines.Requests.Commands;

namespace SchoolManagement.Application.Features.CovidVaccines.Handlers.Commands
{
    public class CreateCovidVaccineCommandHandler : IRequestHandler<CreateCovidVaccineCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCovidVaccineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCovidVaccineCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCovidVaccineDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CovidVaccineDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CovidVaccine = _mapper.Map<CovidVaccine>(request.CovidVaccineDto);

                CovidVaccine = await _unitOfWork.Repository<CovidVaccine>().Add(CovidVaccine);

                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CovidVaccine.CovidVaccineId;
            }

            return response;
        }
    }
}
