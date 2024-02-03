using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ColorOfEyes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ColorOfEyes.Handlers.Queries
{ 
    public class GetSelectedColorOfEyeRequestHandler : IRequestHandler<GetSelectedColorOfEyeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ColorOfEye> _ColorOfEyeRepository;


        public GetSelectedColorOfEyeRequestHandler(ISchoolManagementRepository<ColorOfEye> ColorOfEyeRepository)
        {
            _ColorOfEyeRepository = ColorOfEyeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedColorOfEyeRequest request, CancellationToken cancellationToken)
        {
            ICollection<ColorOfEye> ColorOfEyes = await _ColorOfEyeRepository.FilterAsync(x => x.IsActive && x.ColorOfEyeId != 1010);
            List<SelectedModel> selectModels = ColorOfEyes.Select(x => new SelectedModel 
            {
                Text = x.ColorOfEyeName,
                Value = x.ColorOfEyeId
            }).ToList();
            return selectModels;
        }
    }
}
 