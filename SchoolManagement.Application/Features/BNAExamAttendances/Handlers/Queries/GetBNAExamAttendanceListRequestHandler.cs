using AutoMapper;
using SchoolManagement.Application.DTOs.BnaExamAttendance;
using SchoolManagement.Application.Features.BnaExamAttendances.Requests.Queries;
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
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaExamAttendances.Handlers.Queries
{
    public class GetBnaExamAttendanceListRequestHandler : IRequestHandler<GetBnaExamAttendanceListRequest, PagedResult<BnaExamAttendanceDto>>
    {

        private readonly ISchoolManagementRepository<BnaExamAttendance> _BnaExamAttendanceRepository;

        private readonly IMapper _mapper;

        public GetBnaExamAttendanceListRequestHandler(ISchoolManagementRepository<BnaExamAttendance> BnaExamAttendanceRepository, IMapper mapper)
        {
            _BnaExamAttendanceRepository = BnaExamAttendanceRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaExamAttendanceDto>> Handle(GetBnaExamAttendanceListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BnaExamAttendance> BnaExamAttendances = _BnaExamAttendanceRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText), "BnaSemester", "BnaBatch", "ExamType", "BnaSubjectName");
            var totalCount = BnaExamAttendances.Count();
            BnaExamAttendances = BnaExamAttendances.OrderByDescending(x => x.BnaExamAttendanceId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaExamAttendanceDtos = _mapper.Map<List<BnaExamAttendanceDto>>(BnaExamAttendances);
            var result = new PagedResult<BnaExamAttendanceDto>(BnaExamAttendanceDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
