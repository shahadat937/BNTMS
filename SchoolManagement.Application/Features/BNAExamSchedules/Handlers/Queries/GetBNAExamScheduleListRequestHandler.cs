using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaExamSchedule;
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
using SchoolManagement.Application.Features.BnaExamSchedules.Requests.Queries;

namespace SchoolManagement.Application.Features.BnaExamSchedules.Handlers.Queries
{
    public class GetBnaExamScheduleListRequestHandler : IRequestHandler<GetBnaExamScheduleListRequest, PagedResult<BnaExamScheduleDto>>
    {

        private readonly ISchoolManagementRepository<BnaExamSchedule> _BnaExamScheduleRepository;

        private readonly IMapper _mapper;

        public GetBnaExamScheduleListRequestHandler(ISchoolManagementRepository<BnaExamSchedule> BnaExamScheduleRepository, IMapper mapper)
        {
            _BnaExamScheduleRepository = BnaExamScheduleRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaExamScheduleDto>> Handle(GetBnaExamScheduleListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BnaExamSchedule> BnaExamSchedules = _BnaExamScheduleRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText)), "BnaBatch", "BnaSubjectName", "BnaSemester", "ExamType");
            var totalCount = BnaExamSchedules.Count();
            BnaExamSchedules = BnaExamSchedules.OrderByDescending(x => x.BnaExamScheduleId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaExamScheduleDtos = _mapper.Map<List<BnaExamScheduleDto>>(BnaExamSchedules);
            var result = new PagedResult<BnaExamScheduleDto>(BnaExamScheduleDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
