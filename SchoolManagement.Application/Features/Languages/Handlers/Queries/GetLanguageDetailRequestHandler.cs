using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Languages;
using SchoolManagement.Application.Features.Languages.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Languages.Handlers.Queries
{
    public class GetLanguageDetailRequestHandler : IRequestHandler<GetLanguageDetailRequest, LanguageDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<Language> _LanguageRepository;       
        public GetLanguageDetailRequestHandler(ISchoolManagementRepository<Language> LanguageRepository, IMapper mapper)
        {
            _LanguageRepository = LanguageRepository;    
            _mapper = mapper; 
        } 
        public async Task<LanguageDto> Handle(GetLanguageDetailRequest request, CancellationToken cancellationToken)
        {
            var Language = await _LanguageRepository.Get(request.Id);    
            return _mapper.Map<LanguageDto>(Language);    
        }
    }
}
