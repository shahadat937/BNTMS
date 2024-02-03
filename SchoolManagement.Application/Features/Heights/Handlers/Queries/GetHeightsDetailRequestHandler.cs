using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Heights.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Heights.Handler.Queries
{
    public class GetHeightsDetailRequestHandler : IRequestHandler<GetHeightsDetailRequest, HeightDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<Height> _heightRepository;     
        public GetHeightsDetailRequestHandler(ISchoolManagementRepository<Height> heightRepository, IMapper mapper)
        {
            _heightRepository = heightRepository;  
            _mapper = mapper; 
        }
        public async Task<HeightDto> Handle(GetHeightsDetailRequest request, CancellationToken cancellationToken)
        {
            var height = await _heightRepository.Get(request.Id);   
            return _mapper.Map<HeightDto>(height);  
        }
    }
}
