using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseSections.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseSections.Handlers.Queries 
{
    public class GetSelectedCourseSectionByBaseNameIdAndCourseNameIdRequestHandler : IRequestHandler<GetSelectedCourseSectionByBaseNameIdAndCourseNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseSection> _CourseSectionRepository;


        public GetSelectedCourseSectionByBaseNameIdAndCourseNameIdRequestHandler(ISchoolManagementRepository<CourseSection> CourseSectionRepository)
        {
            _CourseSectionRepository = CourseSectionRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseSectionByBaseNameIdAndCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseSection> CourseSections = _CourseSectionRepository.Where(x=>x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId).ToList();
            List<SelectedModel> selectModels = CourseSections.Select(x => new SelectedModel
            {
                Text = x.SectionName,
                Value = x.CourseSectionId 
            }).ToList();
            return selectModels;
        }
    }
}
