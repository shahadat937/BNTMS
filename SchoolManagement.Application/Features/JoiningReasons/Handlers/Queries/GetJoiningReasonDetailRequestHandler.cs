using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.JoiningReasons;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.JoiningReasons.Requests.Queries;

namespace SchoolManagement.Application.Features.JoiningReasons.Handlers.Queries
{
    public class GetJoiningReasonDetailRequestHandler : IRequestHandler<GetJoiningReasonDetailRequest, JoiningReasonDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<JoiningReason> _JoiningReasonRepository;       
        public GetJoiningReasonDetailRequestHandler(ISchoolManagementRepository<JoiningReason> JoiningReasonRepository, IMapper mapper)
        {
            _JoiningReasonRepository = JoiningReasonRepository;    
            _mapper = mapper; 
        } 
        public async Task<JoiningReasonDto> Handle(GetJoiningReasonDetailRequest request, CancellationToken cancellationToken)
        {
            var JoiningReason = await _JoiningReasonRepository.FindOneAsync(x => x.JoiningReasonId == request.Id, "ReasonType");    
            return _mapper.Map<JoiningReasonDto>(JoiningReason);    
        }
    }
}
