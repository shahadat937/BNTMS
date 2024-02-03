using SchoolManagement.Application.Features.ForeignTrainingCourseReports.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignTrainingCourseReport;
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


namespace SchoolManagement.Application.Features.ForeignTrainingCourseReports.Handlers.Queries
{
    public class GetForeignTrainingReportByStudentListRequestHandler : IRequestHandler<GetForeignTrainingReportByStudentListRequest, PagedResult<ForeignTrainingCourseReportDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ForeignTrainingCourseReport> _ForeignTrainingCourseReportRepository;

        private readonly IMapper _mapper;

        public GetForeignTrainingReportByStudentListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ForeignTrainingCourseReport> ForeignTrainingCourseReportRepository, IMapper mapper)
        {
            _ForeignTrainingCourseReportRepository = ForeignTrainingCourseReportRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ForeignTrainingCourseReportDto>> Handle(GetForeignTrainingReportByStudentListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ForeignTrainingCourseReport> ForeignTrainingCourseReports = _ForeignTrainingCourseReportRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "CourseDuration").Where(x=>x.CourseDurationId==request.CourseDurationId && x.TraineeId==request.TraineeId && x.CourseDuration.IsCompletedStatus == 0);
            var totalCount = ForeignTrainingCourseReports.Count();
            ForeignTrainingCourseReports = ForeignTrainingCourseReports.OrderByDescending(x => x.ForeignTrainingCourseReportid).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ForeignTrainingCourseReportDtos = _mapper.Map<List<ForeignTrainingCourseReportDto>>(ForeignTrainingCourseReports);
            var result = new PagedResult<ForeignTrainingCourseReportDto>(ForeignTrainingCourseReportDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
