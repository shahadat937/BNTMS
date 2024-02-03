using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BaseNames;
using SchoolManagement.Application.Features.BaseNames.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BaseNames.Handlers.Queries
{  
    public class GetBaseNameDetailRequestHandler : IRequestHandler<GetBaseNameDetailRequest, BaseNameDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<BaseName> _BaseNameRepository;       
        public GetBaseNameDetailRequestHandler(ISchoolManagementRepository<BaseName> BaseNameRepository, IMapper mapper)
        {
            _BaseNameRepository = BaseNameRepository;    
            _mapper = mapper; 
        } 
        public async Task<BaseNameDto> Handle(GetBaseNameDetailRequest request, CancellationToken cancellationToken)
        {
            var BaseName = await _BaseNameRepository.Get(request.Id);    
            return _mapper.Map<BaseNameDto>(BaseName);    
        }
    }
}
