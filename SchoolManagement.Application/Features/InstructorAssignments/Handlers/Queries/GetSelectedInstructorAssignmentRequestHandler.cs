using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InstructorAssignments.Handlers.Queries
{
    public class GetSelectedInstructorAssignmentRequestHandler : IRequestHandler<GetSelectedInstructorAssignmentRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<InstructorAssignment> _InstructorAssignmentRepository;


        public GetSelectedInstructorAssignmentRequestHandler(ISchoolManagementRepository<InstructorAssignment> InstructorAssignmentRepository)
        {
            _InstructorAssignmentRepository = InstructorAssignmentRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedInstructorAssignmentRequest request, CancellationToken cancellationToken)
        {
            ICollection<InstructorAssignment> codeValues = await _InstructorAssignmentRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.AssignmentTopic,
                Value = x.InstructorAssignmentId
            }).ToList();
            return selectModels;
        }
    }
}
