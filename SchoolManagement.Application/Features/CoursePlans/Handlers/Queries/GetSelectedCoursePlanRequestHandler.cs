using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CoursePlans.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Queries
{
    public class GetSelectedCoursePlanRequestHandler : IRequestHandler<GetSelectedCoursePlanRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<CoursePlanCreate> _CoursePlanRepository;


        public GetSelectedCoursePlanRequestHandler(ISchoolManagementRepository<CoursePlanCreate> CoursePlanRepository)
        {
            _CoursePlanRepository = CoursePlanRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedCoursePlanRequest request, CancellationToken cancellationToken)
        {
            ICollection<CoursePlanCreate> codeValues = await _CoursePlanRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CoursePlanName,
                Value = x.CoursePlanCreateId 
            }).ToList();
            return selectModels;
        }
    }
}
