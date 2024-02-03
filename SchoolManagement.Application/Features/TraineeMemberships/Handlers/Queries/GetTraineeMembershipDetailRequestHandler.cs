using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeMembership;
using SchoolManagement.Application.Features.TraineeMemberships.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeMemberships.Handlers.Queries
{
    public class GetTraineeMembershipDetailRequestHandler : IRequestHandler<GetTraineeMembershipDetailRequest, TraineeMembershipDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeMembership> _TraineeMembershipRepository;
        public GetTraineeMembershipDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeMembership> TraineeMembershipRepository, IMapper mapper)
        {
            _TraineeMembershipRepository = TraineeMembershipRepository;
            _mapper = mapper;
        }
        public async Task<TraineeMembershipDto> Handle(GetTraineeMembershipDetailRequest request, CancellationToken cancellationToken)
        {
            var TraineeMembership = await _TraineeMembershipRepository.FindOneAsync(x => x.TraineeMembershipId == request.TraineeMembershipId, "MembershipType");
            return _mapper.Map<TraineeMembershipDto>(TraineeMembership);
        }
    }
}
