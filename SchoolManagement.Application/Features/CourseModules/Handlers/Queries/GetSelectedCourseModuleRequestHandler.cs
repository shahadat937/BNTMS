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
    public class GetSelectedCourseModuleRequestHandler : IRequestHandler<GetSelectedCourseModuleRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseModule> _CourseModuleRepository;


        public GetSelectedCourseModuleRequestHandler(ISchoolManagementRepository<CourseModule> CourseModuleRepository)
        {
            _CourseModuleRepository = CourseModuleRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseModuleRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseModule> codeValues = await _CourseModuleRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ModuleName,
                Value = x.CourseModuleId
            }).ToList();
            return selectModels;
        }
    }
}
