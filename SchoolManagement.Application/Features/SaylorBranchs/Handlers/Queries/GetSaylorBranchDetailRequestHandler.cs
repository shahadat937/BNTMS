using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SaylorBranch;
using SchoolManagement.Application.Features.SaylorBranchs.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SaylorBranchs.Handlers.Queries
{
    public class GetSaylorBranchDetailRequestHandler : IRequestHandler<GetSaylorBranchDetailRequest, SaylorBranchDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SaylorBranch> _SaylorBranchRepository;
        public GetSaylorBranchDetailRequestHandler(ISchoolManagementRepository<SaylorBranch> SaylorBranchRepository, IMapper mapper)
        {
            _SaylorBranchRepository = SaylorBranchRepository;
            _mapper = mapper;
        }
        public async Task<SaylorBranchDto> Handle(GetSaylorBranchDetailRequest request, CancellationToken cancellationToken)
        {
            var SaylorBranch = await _SaylorBranchRepository.Get(request.SaylorBranchId);
            return _mapper.Map<SaylorBranchDto>(SaylorBranch);
        }
    }
}
