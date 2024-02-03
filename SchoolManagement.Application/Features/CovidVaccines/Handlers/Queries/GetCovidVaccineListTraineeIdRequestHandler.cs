using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CovidVaccine;
using SchoolManagement.Application.Features.CovidVaccines.Requests;
using SchoolManagement.Application.Features.CovidVaccines.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CovidVaccines.Handlers.Queries
{
    public class GetCovidVaccineListTraineeIdRequestHandler : IRequestHandler<GetCovidVaccineListTraineeIdRequest, List<CovidVaccineDto>>
    {
         
        private readonly ISchoolManagementRepository<CovidVaccine> _CovidVaccineRepository;

        private readonly IMapper _mapper;

        public GetCovidVaccineListTraineeIdRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CovidVaccine> CovidVaccineRepository, IMapper mapper)
        {
            _CovidVaccineRepository = CovidVaccineRepository;
            _mapper = mapper;
        }

        public async Task<List<CovidVaccineDto>> Handle(GetCovidVaccineListTraineeIdRequest request, CancellationToken cancellationToken)
        {
            var CovidVaccines = _CovidVaccineRepository.FilterWithInclude(x => x.TraineeId == request.TraineeId);
            var CovidVaccineDtos = _mapper.Map<List<CovidVaccineDto>>(CovidVaccines);

            return CovidVaccineDtos;
        }
    }
}
