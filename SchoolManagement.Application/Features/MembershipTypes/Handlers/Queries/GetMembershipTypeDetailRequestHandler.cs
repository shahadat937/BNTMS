using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MembershipTypes;
using SchoolManagement.Application.Features.MembershipTypes.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MembershipTypes.Handlers.Queries
{
    public class GetMembershipTypeDetailRequestHandler : IRequestHandler<GetMembershipTypeDetailRequest, MembershipTypeDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<MemberShipType> _MembershipTypeRepository;       
        public GetMembershipTypeDetailRequestHandler(ISchoolManagementRepository<MemberShipType> MembershipTypeRepository, IMapper mapper)
        {
            _MembershipTypeRepository = MembershipTypeRepository;    
            _mapper = mapper; 
        } 
        public async Task<MembershipTypeDto> Handle(GetMembershipTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var MembershipType = await _MembershipTypeRepository.Get(request.Id);    
            return _mapper.Map<MembershipTypeDto>(MembershipType);    
        }
    }
}
