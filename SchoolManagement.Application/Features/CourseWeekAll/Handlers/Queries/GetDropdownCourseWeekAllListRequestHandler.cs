using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Queries;
using SchoolManagement.Application.Features.CourseWeekAll.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseWeekAll.Handlers.Queries
{
    public class GetDropdownCourseWeekAllListRequestHandler : IRequestHandler<GetDropdownCourseWeekAllListRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseWeekAll> _courseWeekRepository;

        public GetDropdownCourseWeekAllListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseWeekAll> courseWeekRepository)
        {
            _courseWeekRepository = courseWeekRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetDropdownCourseWeekAllListRequest request, CancellationToken cancellationToken)
        {
            IQueryable<SchoolManagement.Domain.CourseWeekAll> courseWeekAll = _courseWeekRepository.Where(x => x.IsActive && x.BaseSchoolNameId == request.BaseSchoolNameId);

            List<SelectedModel> selectedModels = courseWeekAll.Select(x=> new SelectedModel
            {
                Text = x.WeekName,
                Value = x.WeekID
            }).ToList();
            return selectedModels;
        }
    }
}
