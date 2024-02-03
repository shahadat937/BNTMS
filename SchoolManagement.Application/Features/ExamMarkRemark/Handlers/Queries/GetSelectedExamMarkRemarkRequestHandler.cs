using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ExamMarkRemark.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamMarkRemark.Handlers.Queries
{
    public class GetSelectedExamMarkRemarkRequestHandler : IRequestHandler<GetSelectedExamMarkRemarkRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ExamMarkRemarks> _ExamMarkRemarksRepository;


        public GetSelectedExamMarkRemarkRequestHandler(ISchoolManagementRepository<ExamMarkRemarks> ExamMarkRemarkRepository)
        {
            _ExamMarkRemarksRepository = ExamMarkRemarkRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedExamMarkRemarkRequest request, CancellationToken cancellationToken)
        {
            ICollection<ExamMarkRemarks> codeValues = await _ExamMarkRemarksRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.MarkRemark,
                Value = x.ExamMarkRemarksId
            }).ToList();
            return selectModels;
        }
    }
}
