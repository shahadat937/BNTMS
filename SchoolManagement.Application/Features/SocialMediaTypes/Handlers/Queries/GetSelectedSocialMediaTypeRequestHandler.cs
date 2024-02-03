using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SocialMediaTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SocialMediaTypes.Handlers.Queries
{
    public class GetSelectedSocialMediaTypeRequestHandler : IRequestHandler<GetSelectedSocialMediaTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SocialMediaType> _SocialMediaTypeRepository;


        public GetSelectedSocialMediaTypeRequestHandler(ISchoolManagementRepository<SocialMediaType> SocialMediaTypeRepository)
        {
            _SocialMediaTypeRepository = SocialMediaTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSocialMediaTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<SocialMediaType> SocialMediaTypes = await _SocialMediaTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = SocialMediaTypes.Select(x => new SelectedModel
            {
                Text = x.SocialMediaTypeName, 
                Value = x.SocialMediaTypeId
            }).ToList();
            return selectModels;
        }
    }
}
