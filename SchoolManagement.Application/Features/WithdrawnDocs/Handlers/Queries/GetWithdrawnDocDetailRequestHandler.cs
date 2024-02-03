using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.WithdrawnDoc;
using SchoolManagement.Application.Features.WithdrawnDocs.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WithdrawnDocs.Handlers.Queries
{
    public class GetWithdrawnDocsDetailRequestHandler : IRequestHandler<GetWithdrawnDocsDetailRequest, WithdrawnDocDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<WithdrawnDoc> _WithdrawnDocRepository;       
        public GetWithdrawnDocsDetailRequestHandler(ISchoolManagementRepository<WithdrawnDoc> WithdrawnDocRepository, IMapper mapper)
        {
            _WithdrawnDocRepository = WithdrawnDocRepository;    
            _mapper = mapper; 
        } 
        public async Task<WithdrawnDocDto> Handle(GetWithdrawnDocsDetailRequest request, CancellationToken cancellationToken)
        {
            var WithdrawnDoc = await _WithdrawnDocRepository.Get(request.Id);    
            return _mapper.Map<WithdrawnDocDto>(WithdrawnDoc);    
        }
    }
}
