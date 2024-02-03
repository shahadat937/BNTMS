using AutoMapper;
using SchoolManagement.Application.DTOs.Attendance;
using SchoolManagement.Application.Features.Attendances.Requests.Queries;
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

namespace SchoolManagement.Application.Features.Attendances.Handlers.Queries
{ 
    public class GetAttendanceListForUpdateRequestHandler : IRequestHandler<GetAttendanceListForUpdateRequest, PagedResult<AttendanceDto>>
    {

        private readonly ISchoolManagementRepository<Attendance> _AttendanceRepository;

        private readonly IMapper _mapper;

        public GetAttendanceListForUpdateRequestHandler(ISchoolManagementRepository<Attendance> AttendanceRepository, IMapper mapper)
        {
            _AttendanceRepository = AttendanceRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AttendanceDto>> Handle(GetAttendanceListForUpdateRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Attendance> Attendances = _AttendanceRepository.FilterWithInclude(x => (x.ClassLeaderName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "BaseSchoolName", "BnaAttendanceRemarks", "BnaSubjectName", "ClassPeriod", "ClassRoutine", "CourseName", "Trainee.Rank").Where(x=>x.BaseSchoolNameId==request.BaseSchoolNameId && x.CourseNameId==request.CourseNameId && x.ClassPeriodId==request.ClassPeriodId);
            var totalCount = Attendances.Count();
            Attendances = Attendances.OrderByDescending(x => x.AttendanceId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AttendanceDtos = _mapper.Map<List<AttendanceDto>>(Attendances);
            var result = new PagedResult<AttendanceDto>(AttendanceDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
