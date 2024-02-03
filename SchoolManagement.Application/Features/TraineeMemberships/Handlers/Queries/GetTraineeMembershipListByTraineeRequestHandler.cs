using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeMembership;
using SchoolManagement.Application.Features.TraineeMemberships.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeMemberships.Handlers.Queries
{
    public class GetTraineeMembershipListByTraineeRequestHandler : IRequestHandler<GetTraineeMembershipListByTraineeRequest, List<TraineeMembershipDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeMembership> _TraineeMembershipRepository;
        public GetTraineeMembershipListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeMembership> TraineeMembershipRepository, IMapper mapper)
        {
            _TraineeMembershipRepository = TraineeMembershipRepository;
            _mapper = mapper;
        }
        public async Task<List<TraineeMembershipDto>> Handle(GetTraineeMembershipListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var TraineeMembership = _TraineeMembershipRepository.FilterWithInclude(x =>(x.TraineeId == request.Traineeid), "MembershipType");
            return _mapper.Map<List<TraineeMembershipDto>>(TraineeMembership);
        }
    }
}
