using AutoMapper;
using SchoolManagement.Application.DTOs.BnaClassSchedule;
using SchoolManagement.Application.Features.BnaClassSchedules.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.BnaClassSchedules.Handlers.Queries
{
    public class GetBnaClassScheduleListRequestHandler : IRequestHandler<GetBnaClassScheduleListRequest, PagedResult<BnaClassScheduleDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaClassSchedule> _BnaClassScheduleRepository;

        private readonly IMapper _mapper;

        public GetBnaClassScheduleListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaClassSchedule> BnaClassScheduleRepository, IMapper mapper)
        {
            _BnaClassScheduleRepository = BnaClassScheduleRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaClassScheduleDto>> Handle(GetBnaClassScheduleListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.BnaClassSchedule> BnaClassSchedules = _BnaClassScheduleRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText), "BnaSemester", "ClassPeriod", "BnaSubjectName", "BnaClassSectionSelection");
            var totalCount = BnaClassSchedules.Count();
            BnaClassSchedules = BnaClassSchedules.OrderByDescending(x => x.BnaClassScheduleId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
            
            var BnaClassScheduleDtos = _mapper.Map<List<BnaClassScheduleDto>>(BnaClassSchedules);
            var result = new PagedResult<BnaClassScheduleDto>(BnaClassScheduleDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
            

        }
    }
}
