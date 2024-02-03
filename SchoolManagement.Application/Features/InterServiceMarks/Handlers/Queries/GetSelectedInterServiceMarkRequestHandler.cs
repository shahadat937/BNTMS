using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.InterServiceMarks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceMarks.Handlers.Queries
{
    public class GetSelectedInterServiceMarkRequestHandler : IRequestHandler<GetSelectedInterServiceMarkRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<InterServiceMark> _InterServiceMarkRepository;


        public GetSelectedInterServiceMarkRequestHandler(ISchoolManagementRepository<InterServiceMark> InterServiceMarkRepository)
        {
            _InterServiceMarkRepository = InterServiceMarkRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedInterServiceMarkRequest request, CancellationToken cancellationToken)
        {
            ICollection<InterServiceMark> InterServiceMarks = await _InterServiceMarkRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = InterServiceMarks.Select(x => new SelectedModel 
            {
                Text = x.ObtaintMark,
                Value = x.InterServiceMarkId
            }).ToList();
            return selectModels;
        }
    }
}
