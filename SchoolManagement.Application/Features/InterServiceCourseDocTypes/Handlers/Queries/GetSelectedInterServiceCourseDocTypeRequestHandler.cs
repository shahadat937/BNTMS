using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceCourseDocTypes.Handlers.Queries
{
    public class GetSelectedInterServiceCourseDocTypeRequestHandler : IRequestHandler<GetSelectedInterServiceCourseDocTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<InterServiceCourseDocType> _InterServiceCourseDocTypeRepository;


        public GetSelectedInterServiceCourseDocTypeRequestHandler(ISchoolManagementRepository<InterServiceCourseDocType> InterServiceCourseDocTypeRepository)
        {
            _InterServiceCourseDocTypeRepository = InterServiceCourseDocTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedInterServiceCourseDocTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<InterServiceCourseDocType> codeValues = await _InterServiceCourseDocTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.InterServiceCourseDocTypeId
            }).ToList();
            return selectModels;
        }
    }
}
