using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseLevels.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseLevels.Handlers.Queries
{ 
    public class GetSelectedCourseLevelRequestHandler : IRequestHandler<GetSelectedCourseLevelRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseLevel> _CourseLevelRepository;


        public GetSelectedCourseLevelRequestHandler(ISchoolManagementRepository<CourseLevel> CourseLevelRepository)
        {
            _CourseLevelRepository = CourseLevelRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseLevelRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseLevel> CourseLevels = await _CourseLevelRepository.FilterAsync(x => x.IsActive && x.CourseLevelId !=26);
            List<SelectedModel> selectModels = CourseLevels.Select(x => new SelectedModel 
            {
                Text = x.CourseLeveTitle,
                Value = x.CourseLevelId
            }).ToList();
            return selectModels;
        }
    }
}
 