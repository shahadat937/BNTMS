using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Handlers.Queries
{
    public class GetSForeignCourseOtherDocForeignCourseOtherDocRequestHandler : IRequestHandler<GetSelectedForeignCourseOtherDocRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ForeignCourseOtherDoc> _ForeignCourseOtherDocRepository;


        public GetSForeignCourseOtherDocForeignCourseOtherDocRequestHandler(ISchoolManagementRepository<ForeignCourseOtherDoc> ForeignCourseOtherDocRepository)
        {
            _ForeignCourseOtherDocRepository = ForeignCourseOtherDocRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedForeignCourseOtherDocRequest request, CancellationToken cancellationToken)
        {
            ICollection<ForeignCourseOtherDoc> codeValues = await _ForeignCourseOtherDocRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CourseName.Course,
                Value = x.ForeignCourseOtherDocId
            }).ToList();
            return selectModels;
        }
    }
}
