using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InterServiceMark;
using SchoolManagement.Application.Features.InterServiceMarks.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceMarks.Handlers.Queries
{
    public class GetInterServiceMarkDetailRequestHandler : IRequestHandler<GetInterServiceMarkDetailRequest, InterServiceMarkDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<InterServiceMark> _InterServiceMarkRepository;
        public GetInterServiceMarkDetailRequestHandler(ISchoolManagementRepository<InterServiceMark> InterServiceMarkRepository, IMapper mapper)
        {
            _InterServiceMarkRepository = InterServiceMarkRepository;
            _mapper = mapper;
        }
        public async Task<InterServiceMarkDto> Handle(GetInterServiceMarkDetailRequest request, CancellationToken cancellationToken)
        {
            var InterServiceMark = await _InterServiceMarkRepository.Get(request.InterServiceMarkId);
            return _mapper.Map<InterServiceMarkDto>(InterServiceMark);
        }
    }
}
