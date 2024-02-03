using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries
{
    public class GetAutoCompleteCourseNameRequestHandler : IRequestHandler<GetAutoCompleteCourseNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseName> _courseNameRepository; 
        public GetAutoCompleteCourseNameRequestHandler(ISchoolManagementRepository<CourseName> courseNameRepository)
        {
            _courseNameRepository = courseNameRepository;
        }
          
        public async Task<List<SelectedModel>> Handle(GetAutoCompleteCourseNameRequest request, CancellationToken cancellationToken)
        {
                ICollection<CourseName> traineeBioDataGeneralInfos = await _courseNameRepository.FilterAsync(x => x.IsActive && x.Course.Contains(request.CourseName));
                var selectModels = traineeBioDataGeneralInfos.Select(x => new SelectedModel
                { 
                    Text = x.Course,
                    Value = x.CourseNameId
                }).ToList();
                return selectModels;
            }
      }
}
