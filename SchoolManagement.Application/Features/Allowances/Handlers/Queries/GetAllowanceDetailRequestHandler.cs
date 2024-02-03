using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Allowance;
using SchoolManagement.Application.Features.Allowances.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Allowances.Handlers.Queries
{
    public class GetAllowanceDetailRequestHandler : IRequestHandler<GetAllowanceDetailRequest, AllowanceDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Allowance> _AllowanceRepository;
        public GetAllowanceDetailRequestHandler(ISchoolManagementRepository<Allowance> AllowanceRepository, IMapper mapper)
        {
            _AllowanceRepository = AllowanceRepository;
            _mapper = mapper;
        }
        public async Task<AllowanceDto> Handle(GetAllowanceDetailRequest request, CancellationToken cancellationToken)
        {
            var Allowance =_AllowanceRepository.FinedOneInclude(x=>x.AllowanceId==request.AllowanceId, "AllowanceCategory.AllowancePercentage");
            return _mapper.Map<AllowanceDto>(Allowance);
        }
    }
}
