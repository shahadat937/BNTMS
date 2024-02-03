using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.KindOfSubjects;
using SchoolManagement.Application.Features.KindOfSubjects.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.KindOfSubjects.Handler.Queries    
{  
    public class GetKindOfSubjectDetailRequestHandler : IRequestHandler<GetKindOfSubjectDetailRequest, KindOfSubjectDto>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<KindOfSubject> _KindOfSubjectRepository;     
        public GetKindOfSubjectDetailRequestHandler(ISchoolManagementRepository<KindOfSubject> KindOfSubjectRepository, IMapper mapper)
        {
            _KindOfSubjectRepository = KindOfSubjectRepository;  
            _mapper = mapper; 
        }
        public async Task<KindOfSubjectDto> Handle(GetKindOfSubjectDetailRequest request, CancellationToken cancellationToken)
        {
            var KindOfSubject = await _KindOfSubjectRepository.Get(request.Id);   
            return _mapper.Map<KindOfSubjectDto>(KindOfSubject);  
        }
    }
}
