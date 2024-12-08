using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.CourseDurations.Requests;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
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
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseDurationListRequestHandler : IRequestHandler<GetCourseDurationListRequest, PagedResult<CourseDurationDto>>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

        private readonly IMapper _mapper;

        public GetCourseDurationListRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseDurationDto>> Handle(GetCourseDurationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            string trimmedSearchText = request.QueryParams.SearchText?.Trim() ?? string.Empty;

            // Normalize the search text: Remove extra spaces and convert to lowercase
            string normalizedSearchText = trimmedSearchText.Replace(" ", "").ToLower();

            IQueryable<CourseDuration> CourseDurations = _CourseDurationRepository.FilterWithInclude(
                x =>
                 
                    EF.Functions.Like(
                        (x.CourseName.Course + " - " + x.CourseTitle).Replace(" ", "").ToLower(),
                        $"%{normalizedSearchText}%") ||

                    x.CourseTitle.Contains(trimmedSearchText) ||

                  
                    string.IsNullOrEmpty(trimmedSearchText) ||

                    
                    EF.Functions.Like(
                        x.CourseName.Course.Trim() + " - " + x.CourseTitle.Trim(),
                        $"%{trimmedSearchText}%"),
                "CourseName",
                "BaseSchoolName",
                "OrganizationName"
            );



            var totalCount = CourseDurations.Count();
            CourseDurations = CourseDurations.OrderByDescending(x => x.CourseDurationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize).Where(x=>x.IsCompletedStatus==0);

            var CourseDurationDtos = _mapper.Map<List<CourseDurationDto>>(CourseDurations);
            var result = new PagedResult<CourseDurationDto>(CourseDurationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
