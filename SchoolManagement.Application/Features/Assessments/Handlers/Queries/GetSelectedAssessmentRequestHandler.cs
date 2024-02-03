using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Assessments.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Assessments.Handlers.Queries
{
    public class GetSelectedAssessmentRequestHandler : IRequestHandler<GetSelectedAssessmentRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Assessment> _AssessmentRepository;


        public GetSelectedAssessmentRequestHandler(ISchoolManagementRepository<Assessment> AssessmentRepository)
        {
            _AssessmentRepository = AssessmentRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAssessmentRequest request, CancellationToken cancellationToken)
        {
            ICollection<Assessment> codeValues = await _AssessmentRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.AssessmentId
            }).ToList();
            return selectModels;
        }
    }
}
