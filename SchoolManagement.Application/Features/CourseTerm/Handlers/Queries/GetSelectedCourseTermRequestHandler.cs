using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseTerms.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseTerms.Handlers.Queries
{ 
    public class GetSelectedCourseTermRequestHandler : IRequestHandler<GetSelectedCourseTermRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseTerm> _CourseTermRepository;


        public GetSelectedCourseTermRequestHandler(ISchoolManagementRepository<CourseTerm> CourseTermRepository)
        {
            _CourseTermRepository = CourseTermRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseTermRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseTerm> CourseTerms = await _CourseTermRepository.FilterAsync(x => x.IsActive && x.CourseTermId !=26);
            List<SelectedModel> selectModels = CourseTerms.Select(x => new SelectedModel 
            {
                Text = x.CourseTermTitle,
                Value = x.CourseTermId
            }).ToList();
            return selectModels;
        }
    }
}
 