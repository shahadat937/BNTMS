using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.CourseWeekAll;
using SchoolManagement.Application.Features.CourseWeekAll.Requests.Queries;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseWeekAll.Handlers.Queries
{
    public class GetCourseWeekAllListRequestHandler :IRequestHandler<GetCourseWeekAllListRequest, PagedResult<CourseWeekAllDto>>
    {
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseWeekAll> _CourseWeekRepository;
        private readonly IMapper _mapper;
        public GetCourseWeekAllListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseWeekAll> CourseWeekRepository, IMapper mapper)
        {
            _CourseWeekRepository = CourseWeekRepository;
            _mapper = mapper;
        }




        public async Task<PagedResult<CourseWeekAllDto>> Handle(GetCourseWeekAllListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);



           IQueryable<SchoolManagement.Domain.CourseWeekAll> CourseWeeks = _CourseWeekRepository.FilterWithInclude(x => x.WeekName.Contains(request.QueryParams.SearchText)).Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId);

           // IQueryable<SchoolManagement.Domain.CourseWeekAll> CourseWeeks = _CourseWeekRepository.FilterWithInclude(x => x.WeekName.Contains(request.QueryParams.SearchText)).Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId);

            var CourseWeekDtos = _mapper.Map<List<CourseWeekAllDto>>(CourseWeeks);
            var totalCount = CourseWeeks.Count();
            var result = new PagedResult<CourseWeekAllDto>(CourseWeekDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }

    }
}
