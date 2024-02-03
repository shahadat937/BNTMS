using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SaylorSubBranch;
using SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Handlers.Queries
{
    public class GetSaylorSubBranchDetailRequestHandler : IRequestHandler<GetSaylorSubBranchDetailRequest, SaylorSubBranchDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SaylorSubBranch> _SaylorSubBranchRepository;
        public GetSaylorSubBranchDetailRequestHandler(ISchoolManagementRepository<SaylorSubBranch> SaylorSubBranchRepository, IMapper mapper)
        {
            _SaylorSubBranchRepository = SaylorSubBranchRepository;
            _mapper = mapper;
        }
        public async Task<SaylorSubBranchDto> Handle(GetSaylorSubBranchDetailRequest request, CancellationToken cancellationToken)
        {
            var SaylorSubBranch = await _SaylorSubBranchRepository.Get(request.SaylorSubBranchId);
            return _mapper.Map<SaylorSubBranchDto>(SaylorSubBranch);
        }
    }
}
