using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ExamCenters.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamCenters.Handlers.Queries
{
    public class GetSelectedExamCenterRequestHandler : IRequestHandler<GetSelectedExamCenterRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ExamCenter> _ExamCenterRepository;


        public GetSelectedExamCenterRequestHandler(ISchoolManagementRepository<ExamCenter> ExamCenterRepository)
        {
            _ExamCenterRepository = ExamCenterRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedExamCenterRequest request, CancellationToken cancellationToken)
        {
            ICollection<ExamCenter> ExamCenters = await _ExamCenterRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = ExamCenters.Select(x => new SelectedModel 
            {
                Text = x.ExamCenterName,
                Value = x.ExamCenterId
            }).ToList();
            return selectModels;
        }
    }
}
