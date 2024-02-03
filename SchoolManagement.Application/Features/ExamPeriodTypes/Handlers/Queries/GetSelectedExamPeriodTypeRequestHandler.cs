using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamPeriodTypes.Handlers.Queries
{
    public class GetSelectedExamPeriodTypeRequestHandler : IRequestHandler<GetSelectedExamPeriodTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ExamPeriodType> _ExamPeriodTypeRepository;


        public GetSelectedExamPeriodTypeRequestHandler(ISchoolManagementRepository<ExamPeriodType> ExamPeriodTypeRepository)
        {
            _ExamPeriodTypeRepository = ExamPeriodTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedExamPeriodTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ExamPeriodType> codeValues = await _ExamPeriodTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ExamPeriodName,
                Value = x.ExamPeriodTypeId
            }).ToList();
            return selectModels;
        }
    }
}
