using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ExamTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamTypes.Handlers.Queries
{
    public class GetSelectedExamTypeRequestHandler : IRequestHandler<GetSelectedExamTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ExamType> _ExamTypeRepository;


        public GetSelectedExamTypeRequestHandler(ISchoolManagementRepository<ExamType> ExamTypeRepository)
        {
            _ExamTypeRepository = ExamTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedExamTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ExamType> codeValues = await _ExamTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ExamTypeName,
                Value = x.ExamTypeId
            }).ToList();
            return selectModels;
        }
    }
}
