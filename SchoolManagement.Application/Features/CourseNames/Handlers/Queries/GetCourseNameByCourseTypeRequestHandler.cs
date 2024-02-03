using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseNames.Handlers.Queries
{
    public class GetCourseNameByCourseTypeRequestHandler : IRequestHandler<GetCourseNameByCourseTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseName> _courseNameRepository; 
        public GetCourseNameByCourseTypeRequestHandler(ISchoolManagementRepository<CourseName> courseNameRepository)
        {
            _courseNameRepository = courseNameRepository;
        }
          
        public async Task<List<SelectedModel>> Handle(GetCourseNameByCourseTypeRequest request, CancellationToken cancellationToken)
        {
            //ICollection<CourseName> courseNames = await _courseNameRepository.FilterAsync(x => x.IsActive && x.CourseTypeId == request.CourseTypeId && x.Course.Contains(request.CourseName));
            ICollection<CourseName> courseNames = await _courseNameRepository.FilterAsync(x => x.IsActive && x.CourseTypeId == request.CourseTypeId);
            var selectModels = courseNames.Select(x => new SelectedModel
                { 
                    Text = x.Course,
                    Value = x.CourseNameId
                }).ToList();
                return selectModels;
            }
      }
}
