using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseDurationListBySchoolRequestHandler : IRequestHandler<GetCourseDurationListBySchoolRequest, PagedResult<CourseDurationDto>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

        private readonly IMapper _mapper;

        public GetCourseDurationListBySchoolRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<CourseDurationDto>> Handle(GetCourseDurationListBySchoolRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            //if (validationResult.IsValid == false)

            //    throw new ValidationException(validationResult);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errorMessage);
            }

            string trimmedSearchText = request.QueryParams.SearchText?.Trim() ?? string.Empty;


            string normalizedSearchText = trimmedSearchText.Replace(" ", "").ToLower();

            IQueryable<CourseDuration> CourseDurations = _CourseDurationRepository.FilterWithInclude(
               x => x.BaseSchoolNameId == request.BaseSchoolNameId &&

                    (EF.Functions.Like(
                        (x.CourseName.Course + " - " + x.CourseTitle).Replace(" ", "").ToLower(),
                        $"%{normalizedSearchText}%") ||

                    x.CourseTitle.Contains(trimmedSearchText) ||


                    string.IsNullOrEmpty(trimmedSearchText) ||


                    EF.Functions.Like(
                        x.CourseName.Course.Trim() + " - " + x.CourseTitle.Trim(),
                        $"%{trimmedSearchText}%")),
                "CourseName",
                "BaseSchoolName",
                "OrganizationName"
            );
            var totalCount = CourseDurations.Count();
            CourseDurations = CourseDurations.OrderByDescending(x => x.CourseDurationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
            //.Where(x => x.IsCompletedStatus == 0);

            var CourseDurationDtos = _mapper.Map<List<CourseDurationDto>>(CourseDurations);
            var result = new PagedResult<CourseDurationDto>(CourseDurationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
