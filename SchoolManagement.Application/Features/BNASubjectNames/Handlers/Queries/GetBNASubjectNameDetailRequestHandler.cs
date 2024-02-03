using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{  
    public class GetBnaSubjectNameDetailRequestHandler : IRequestHandler<GetBnaSubjectNameDetailRequest, BnaSubjectNameDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;       
        public GetBnaSubjectNameDetailRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, IMapper mapper)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;    
            _mapper = mapper; 
        } 
        public async Task<BnaSubjectNameDto> Handle(GetBnaSubjectNameDetailRequest request, CancellationToken cancellationToken)
        {
            //var BnaSubjectName = await _BnaSubjectNameRepository.Get(request.Id);
             var BnaSubjectName = _BnaSubjectNameRepository.FinedOneInclude(x => x.BnaSubjectNameId == request.Id, "CourseName", "CourseModule");
            return _mapper.Map<BnaSubjectNameDto>(BnaSubjectName);    
        }
    }
}
