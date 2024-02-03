using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseDocTypes.Handlers.Queries
{
    public class GetSelectedForeignCourseDocTypeRequestHandler : IRequestHandler<GetSelectedForeignCourseDocTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ForeignCourseDocType> _ForeignCourseDocTypeRepository;


        public GetSelectedForeignCourseDocTypeRequestHandler(ISchoolManagementRepository<ForeignCourseDocType> ForeignCourseDocTypeRepository)
        {
            _ForeignCourseDocTypeRepository = ForeignCourseDocTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedForeignCourseDocTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ForeignCourseDocType> codeValues = await _ForeignCourseDocTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.ForeignCourseDocTypeId
            }).ToList();
            return selectModels;
        }
    }
}
