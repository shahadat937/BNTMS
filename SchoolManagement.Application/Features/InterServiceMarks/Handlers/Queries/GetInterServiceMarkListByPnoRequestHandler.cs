using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InterServiceMark;
using SchoolManagement.Application.Features.InterServiceMarks.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.InterServiceMarks.Handlers.Queries
{
    public class GetInterServiceMarkListByPnoRequestHandler : IRequestHandler<GetInterServiceMarkListByPnoRequest, List<InterServiceMarkDto>>
    {
        private readonly ISchoolManagementRepository<InterServiceMark> _InterServiceMarkRepository;
        private readonly IMapper _mapper;

        public GetInterServiceMarkListByPnoRequestHandler(ISchoolManagementRepository<InterServiceMark> InterServiceMarkRepository, IMapper mapper)
        {
            _InterServiceMarkRepository = InterServiceMarkRepository;
            _mapper = mapper;
        }
         
        public async Task<List<InterServiceMarkDto>> Handle(GetInterServiceMarkListByPnoRequest request, CancellationToken cancellationToken)
        {
            ICollection<InterServiceMark> InterServiceMarks = _InterServiceMarkRepository.FilterWithInclude(x=> x.TraineeId == request.TraineeId, "Document").ToList();
            
            var InterServiceMarkDtos = _mapper.Map<List<InterServiceMarkDto>>(InterServiceMarks);
            return InterServiceMarkDtos; 
        }
    }
}
