﻿using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetSelectedCourseNameByCourseTypeIdFromCourseDurationRequestHandler : IRequestHandler<GetSelectedCourseNameByCourseTypeIdFromCourseDurationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;


        public GetSelectedCourseNameByCourseTypeIdFromCourseDurationRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository)
        {
            _CourseDurationRepository = CourseDurationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseNameByCourseTypeIdFromCourseDurationRequest request, CancellationToken cancellationToken)
        {
            //ICollection<CourseDuration> CourseDurations = await _CourseDurationRepository.FilterAsync(x => x.IsActive);
            //var CourseDurations = await _CourseDurationRepository.FilterWithInclude(x => x.IsActive, "AllowancePercentage");
            IQueryable<CourseDuration> CourseDurations = _CourseDurationRepository.FilterWithInclude(x => x.IsActive, "CourseName").Where(x =>x.CourseTypeId==request.CourseTypeId);
            List<SelectedModel> selectModels = CourseDurations.Select(x => new SelectedModel 
            {
                Text = x.CourseName.Course,
                Value = x.CourseDurationId
            }).ToList();
            return selectModels;
        }
    }
}
