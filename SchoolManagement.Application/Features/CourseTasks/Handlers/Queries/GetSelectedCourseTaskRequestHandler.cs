using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseTasks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseTasks.Handlers.Queries
{
    public class GetSelectedCourseTaskRequestHandler : IRequestHandler<GetSelectedCourseTaskRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseTask> _CourseTaskRepository;


        public GetSelectedCourseTaskRequestHandler(ISchoolManagementRepository<CourseTask> CourseTaskRepository)
        {
            _CourseTaskRepository = CourseTaskRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseTaskRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseTask> codeValues = await _CourseTaskRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.TaskDetail,
                Value = x.CourseTaskId
            }).ToList();
            return selectModels;
        }
    }
}
