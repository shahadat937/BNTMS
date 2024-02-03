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
    public class GetSelectedCourseModuleByBaseSchoolNameIdRequestHandler : IRequestHandler<GetSelectedCourseModuleByBaseSchoolNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseModule> _CourseModuleRepository;


        public GetSelectedCourseModuleByBaseSchoolNameIdRequestHandler(ISchoolManagementRepository<CourseModule> CourseModuleRepository)
        {
            _CourseModuleRepository = CourseModuleRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseModuleByBaseSchoolNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseModule> CourseModules = await _CourseModuleRepository.FilterAsync(x => x.BaseSchoolNameId == request.BaseSchoolNameId);
            List<SelectedModel> selectModels = CourseModules.Select(x => new SelectedModel
            {
                Text = x.ModuleName,
                Value = x.CourseModuleId
            }).ToList();
            return selectModels;
        }
    }
}
