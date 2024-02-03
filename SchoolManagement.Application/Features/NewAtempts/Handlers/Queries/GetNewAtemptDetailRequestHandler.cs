using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NewAtempt;
using SchoolManagement.Application.Features.NewAtempts.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NewAtempts.Handlers.Queries
{
    public class GetNewAtemptDetailRequestHandler : IRequestHandler<GetNewAtemptDetailRequest, NewAtemptDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<NewAtempt> _NewAtemptRepository;
        public GetNewAtemptDetailRequestHandler(ISchoolManagementRepository<NewAtempt> NewAtemptRepository, IMapper mapper)
        {
            _NewAtemptRepository = NewAtemptRepository;
            _mapper = mapper;
        }
        public async Task<NewAtemptDto> Handle(GetNewAtemptDetailRequest request, CancellationToken cancellationToken)
        {
            var NewAtempt = await _NewAtemptRepository.Get(request.NewAtemptId);
            return _mapper.Map<NewAtemptDto>(NewAtempt);
        }
    }
}
