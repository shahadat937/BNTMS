using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Complexions.Handler.Queries   
{ 
    public class GetComplexionsDetailRequestHandler : IRequestHandler<GetComplexionsDetailRequest, ComplexionDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<Complexion> _complexionRepository;   
        public GetComplexionsDetailRequestHandler(ISchoolManagementRepository<Complexion> complexionRepository, IMapper mapper)
        {
            _complexionRepository = complexionRepository; 
            _mapper = mapper; 
        }
        public async Task<ComplexionDto> Handle(GetComplexionsDetailRequest request, CancellationToken cancellationToken)
        {
            var complexion = await _complexionRepository.Get(request.Id); 
            return _mapper.Map<ComplexionDto>(complexion); 
        }
    }
}
