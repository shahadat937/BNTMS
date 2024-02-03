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
    public class GetSelectedCourseSectionByBaseSchoolNameIdRequestHandler : IRequestHandler<GetSelectedCourseSectionByBaseSchoolNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseSection> _CourseSectionRepository;


        public GetSelectedCourseSectionByBaseSchoolNameIdRequestHandler(ISchoolManagementRepository<CourseSection> CourseSectionRepository)
        {
            _CourseSectionRepository = CourseSectionRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseSectionByBaseSchoolNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseSection> CourseSections = await _CourseSectionRepository.FilterAsync(x => x.BaseSchoolNameId == request.BaseSchoolNameId);
            List<SelectedModel> selectModels = CourseSections.Select(x => new SelectedModel
            {
                Text = x.SectionName,
                Value = x.CourseSectionId
            }).ToList();
            return selectModels;
        }
    }
}
