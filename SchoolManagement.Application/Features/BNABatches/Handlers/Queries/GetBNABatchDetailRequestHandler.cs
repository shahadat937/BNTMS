using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaBatch;
using SchoolManagement.Application.Features.BnaBatches.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaBatches.Handlers.Queries
{
    public class GetBnaBatchDetailRequestHandler : IRequestHandler<GetBnaBatchDetailRequest, BnaBatchDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BnaBatch> _BnaBatchRepository;
        public GetBnaBatchDetailRequestHandler(ISchoolManagementRepository<BnaBatch> BnaBatchRepository, IMapper mapper)
        {
            _BnaBatchRepository = BnaBatchRepository;
            _mapper = mapper;
        }
        public async Task<BnaBatchDto> Handle(GetBnaBatchDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaBatch = await _BnaBatchRepository.Get(request.BnaBatchId);
            return _mapper.Map<BnaBatchDto>(BnaBatch);
        }
    }
}
