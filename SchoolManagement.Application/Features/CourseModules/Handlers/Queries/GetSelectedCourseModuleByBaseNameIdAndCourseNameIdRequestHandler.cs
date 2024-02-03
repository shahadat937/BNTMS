using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseModules.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseModules.Handlers.Queries 
{
    public class GetSelectedCourseModuleByBaseNameIdAndCourseNameIdRequestHandler : IRequestHandler<GetSelectedCourseModuleByBaseNameIdAndCourseNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseModule> _CourseModuleRepository;


        public GetSelectedCourseModuleByBaseNameIdAndCourseNameIdRequestHandler(ISchoolManagementRepository<CourseModule> CourseModuleRepository)
        {
            _CourseModuleRepository = CourseModuleRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseModuleByBaseNameIdAndCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseModule> courseModules = _CourseModuleRepository.Where(x=>x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId).ToList();
            List<SelectedModel> selectModels = courseModules.Select(x => new SelectedModel
            {
                Text = x.ModuleName,
                Value = x.CourseModuleId 
            }).ToList();
            return selectModels;
        }
    }
}
