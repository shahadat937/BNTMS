using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamAttemptTypes.Handlers.Queries
{
    public class GetSelectedExamAttemptTypeRequestHandler : IRequestHandler<GetSelectedExamAttemptTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ExamAttemptType> _ExamAttemptTypeRepository;


        public GetSelectedExamAttemptTypeRequestHandler(ISchoolManagementRepository<ExamAttemptType> ExamAttemptTypeRepository)
        {
            _ExamAttemptTypeRepository = ExamAttemptTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedExamAttemptTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ExamAttemptType> ExamAttemptTypes = await _ExamAttemptTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = ExamAttemptTypes.Select(x => new SelectedModel 
            {
                Text = x.ExamAttemptTypeName,
                Value = x.ExamAttemptTypeId
            }).ToList();
            return selectModels;
        }
    }
}
