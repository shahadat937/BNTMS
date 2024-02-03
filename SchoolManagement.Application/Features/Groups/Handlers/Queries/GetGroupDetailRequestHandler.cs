using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Groups;
using SchoolManagement.Application.Features.Groups.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Groups.Handlers.Queries
{
    public class GetGroupDetailRequestHandler : IRequestHandler<GetGroupsDetailRequest, GroupDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<Group> _GroupRepository;       
        public GetGroupDetailRequestHandler(ISchoolManagementRepository<Group> GroupRepository, IMapper mapper)
        {
            _GroupRepository = GroupRepository;    
            _mapper = mapper; 
        } 
        public async Task<GroupDto> Handle(GetGroupsDetailRequest request, CancellationToken cancellationToken)
        {
            var Group = await _GroupRepository.Get(request.Id);    
            return _mapper.Map<GroupDto>(Group);    
        }
    }
}
