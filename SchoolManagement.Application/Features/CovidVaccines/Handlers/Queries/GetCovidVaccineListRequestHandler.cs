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

namespace SchoolManagement.Application.Features.CovidVaccines.Handlers.Queries
{
    public class GetCovidVaccineListRequestHandler : IRequestHandler<GetCovidVaccineListRequest, PagedResult<CovidVaccineDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CovidVaccine> _CovidVaccineRepository;

        private readonly IMapper _mapper;

        public GetCovidVaccineListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CovidVaccine> CovidVaccineRepository, IMapper mapper)
        {
            _CovidVaccineRepository = CovidVaccineRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CovidVaccineDto>> Handle(GetCovidVaccineListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.CovidVaccine> CovidVaccines = _CovidVaccineRepository.FilterWithInclude(x =>String.IsNullOrEmpty(request.QueryParams.SearchText));
            var totalCount = CovidVaccines.Count();
            CovidVaccines = CovidVaccines.OrderByDescending(x => x.CovidVaccineId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CovidVaccineDtos = _mapper.Map<List<CovidVaccineDto>>(CovidVaccines);
            var result = new PagedResult<CovidVaccineDto>(CovidVaccineDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
