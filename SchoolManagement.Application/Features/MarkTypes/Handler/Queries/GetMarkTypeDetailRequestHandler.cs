using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MarkType;
using SchoolManagement.Application.Features.MarkTypes.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MarkTypes.Handler.Queries
{
    public class GetMarkTypeDetailRequestHandler : IRequestHandler<GetMarkTypeDetailRequest, MarkTypeDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<MarkType> _MarkTypeRepository; 
        public GetMarkTypeDetailRequestHandler(ISchoolManagementRepository<MarkType> MarkTypeRepository, IMapper mapper)
        {
            _MarkTypeRepository = MarkTypeRepository; 
            _mapper = mapper;
        }
        public async Task<MarkTypeDto> Handle(GetMarkTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var MarkType = await _MarkTypeRepository.Get(request.Id);
            return _mapper.Map<MarkTypeDto>(MarkType);
        }
    }
}
