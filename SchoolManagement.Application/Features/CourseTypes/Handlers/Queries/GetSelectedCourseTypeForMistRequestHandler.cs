using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseTypes.Handlers.Queries
{
    public class GetSelectedCourseTypeForMistRequestHandler : IRequestHandler<GetSelectedCourseTypeForMistRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CourseType> _CourseTypeRepository;


        public GetSelectedCourseTypeForMistRequestHandler(ISchoolManagementRepository<CourseType> CourseTypeRepository)
        {
            _CourseTypeRepository = CourseTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCourseTypeForMistRequest request, CancellationToken cancellationToken)
        {
            ICollection<CourseType> codeValues = await _CourseTypeRepository.FilterAsync(x => x.IsActive && x.CourseTypeId ==1033);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CourseTypeName,
                Value = x.CourseTypeId
            }).ToList();
            return selectModels;
        }
    }
}
