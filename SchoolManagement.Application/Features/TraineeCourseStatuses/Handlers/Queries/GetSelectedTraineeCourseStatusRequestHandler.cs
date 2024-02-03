using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeCourseStatuses.Handlers.Queries
{ 
    public class GetSelectedTraineeCourseStatusRequestHandler : IRequestHandler<GetSelectedTraineeCourseStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TraineeCourseStatus> _TraineeCourseStatusRepository;


        public GetSelectedTraineeCourseStatusRequestHandler(ISchoolManagementRepository<TraineeCourseStatus> TraineeCourseStatusRepository)
        {
            _TraineeCourseStatusRepository = TraineeCourseStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTraineeCourseStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<TraineeCourseStatus> TraineeCourseStatuses = await _TraineeCourseStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = TraineeCourseStatuses.Select(x => new SelectedModel 
            {
                Text = x.TraineeCourseStatusName,
                Value = x.TraineeCourseStatusId
            }).ToList();
            return selectModels;
        }
    }
}
