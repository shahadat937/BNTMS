﻿using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq; 
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseNames.Handlers.Queries
{ 
    public class GetSelectedCourseNameByTypeRequestHandler : IRequestHandler<GetSelectedCourseNameByTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseName> _CourseNameRepository;


        public GetSelectedCourseNameByTypeRequestHandler(ISchoolManagementRepository<CourseName> CourseNameRepository)
        {
            _CourseNameRepository = CourseNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseNameByTypeRequest request, CancellationToken cancellationToken)
        {
            
            ICollection<CourseName> courseNames = await _CourseNameRepository.FilterAsync(x => x.CourseTypeId == request.CourseTypeId);

          
            var sortedCourses = courseNames.OrderByDescending(c => c.DateCreated).ToList();

           
            List<SelectedModel> selectModels = sortedCourses.Select(x => new SelectedModel
            {
                Text = x.Course,
                Value = x.CourseNameId
            }).ToList();

            return selectModels;
        }
    }
}
