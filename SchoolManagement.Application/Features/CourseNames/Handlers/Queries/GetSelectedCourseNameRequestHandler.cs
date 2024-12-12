using MediatR;
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
    public class GetSelectedCourseNameRequestHandler : IRequestHandler<GetSelectedCourseNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseName> _CourseNameRepository;


        public GetSelectedCourseNameRequestHandler(ISchoolManagementRepository<CourseName> CourseNameRepository)
        {
            _CourseNameRepository = CourseNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseName> CourseNames = await _CourseNameRepository.FilterAsync(x => x.IsActive);
            var sortByDecending = CourseNames.OrderByDescending(c => c.DateCreated).ToList();
            List<SelectedModel> selectModels = sortByDecending.Select(x => new SelectedModel 
            {
                Text = x.Course, 
                Value = x.CourseNameId
            }).ToList();
            return selectModels;
        }
    }
}
