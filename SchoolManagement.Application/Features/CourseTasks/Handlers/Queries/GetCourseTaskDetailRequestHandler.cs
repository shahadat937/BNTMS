using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseTask;
using SchoolManagement.Application.Features.CourseTasks.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseTasks.Handlers.Queries
{
    public class GetCourseTaskDetailRequestHandler : IRequestHandler<GetCourseTaskDetailRequest, CourseTaskDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseTask> _CourseTaskRepository;
        public GetCourseTaskDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseTask> CourseTaskRepository, IMapper mapper)
        {
            _CourseTaskRepository = CourseTaskRepository;
            _mapper = mapper;
        }
        public async Task<CourseTaskDto> Handle(GetCourseTaskDetailRequest request, CancellationToken cancellationToken)
        {
            var CourseTask = _CourseTaskRepository.FinedOneInclude(x=>x.CourseTaskId == request.CourseTaskId,"CourseName");
            return _mapper.Map<CourseTaskDto>(CourseTask);
        }
    }
}
