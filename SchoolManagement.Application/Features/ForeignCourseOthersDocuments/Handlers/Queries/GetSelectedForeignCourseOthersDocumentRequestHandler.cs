using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Handlers.Queries
{
    public class GetSelectedForeignCourseOthersDocumentRequestHandler : IRequestHandler<GetSelectedForeignCourseOthersDocumentRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ForeignCourseOthersDocument> _ForeignCourseOthersDocumentRepository;


        public GetSelectedForeignCourseOthersDocumentRequestHandler(ISchoolManagementRepository<ForeignCourseOthersDocument> ForeignCourseOthersDocumentRepository)
        {
            _ForeignCourseOthersDocumentRepository = ForeignCourseOthersDocumentRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedForeignCourseOthersDocumentRequest request, CancellationToken cancellationToken)
        {
            ICollection<ForeignCourseOthersDocument> codeValues = await _ForeignCourseOthersDocumentRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ForeignCourseDocType,
                Value = x.ForeignCourseOthersDocumentId
            }).ToList();
            return selectModels;
        }
    }
}
