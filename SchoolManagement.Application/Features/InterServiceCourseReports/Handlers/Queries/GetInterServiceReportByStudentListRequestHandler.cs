using SchoolManagement.Application.Features.InterServiceCourseReports.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InterServiceCourseReport;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;


namespace SchoolManagement.Application.Features.InterServiceCourseReports.Handlers.Queries
{
    public class GetInterServiceReportByStudentListRequestHandler : IRequestHandler<GetInterServiceReportByStudentListRequest, PagedResult<InterServiceCourseReportDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.InterServiceCourseReport> _InterServiceCourseReportRepository;

        private readonly IMapper _mapper;

        public GetInterServiceReportByStudentListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.InterServiceCourseReport> InterServiceCourseReportRepository, IMapper mapper)
        {
            _InterServiceCourseReportRepository = InterServiceCourseReportRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<InterServiceCourseReportDto>> Handle(GetInterServiceReportByStudentListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.InterServiceCourseReport> InterServiceCourseReports = _InterServiceCourseReportRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "CourseDuration").Where(x=>x.CourseDurationId==request.CourseDurationId && x.TraineeId==request.TraineeId && x.CourseDuration.IsCompletedStatus == 0);
            var totalCount = InterServiceCourseReports.Count();
            InterServiceCourseReports = InterServiceCourseReports.OrderByDescending(x => x.InterServiceCourseReportid).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var InterServiceCourseReportDtos = _mapper.Map<List<InterServiceCourseReportDto>>(InterServiceCourseReports);
            var result = new PagedResult<InterServiceCourseReportDto>(InterServiceCourseReportDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
