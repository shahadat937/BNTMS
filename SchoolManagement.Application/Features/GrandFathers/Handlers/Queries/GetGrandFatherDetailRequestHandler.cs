using AutoMapper;
using SchoolManagement.Application.DTOs.GrandFather;
using SchoolManagement.Application.Features.GrandFathers.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GrandFathers.Handlers.Queries
{
    public class GetGrandFatherDetailRequestHandler : IRequestHandler<GetGrandFatherDetailRequest, GrandFatherDto>
    {
       // private readonly IGrandFatherRepository _GrandFatherRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GrandFather> _GrandFatherRepository;
        public GetGrandFatherDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GrandFather>  GrandFatherRepository, IMapper mapper)
        {
            _GrandFatherRepository = GrandFatherRepository;
            _mapper = mapper;
        }
        public async Task<GrandFatherDto> Handle(GetGrandFatherDetailRequest request, CancellationToken cancellationToken)
        {
            var GrandFather = await _GrandFatherRepository.FindOneAsync(x => x.GrandFatherId == request.GrandFatherId, "GrandFatherType", "Occupation", "Nationality", "DeadStatusNavigation");
            return _mapper.Map<GrandFatherDto>(GrandFather);
        }
    }
}
