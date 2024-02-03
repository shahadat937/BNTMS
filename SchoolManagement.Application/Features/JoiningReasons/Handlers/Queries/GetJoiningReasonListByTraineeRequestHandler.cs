using AutoMapper;
using SchoolManagement.Application.DTOs.JoiningReasons;
using SchoolManagement.Application.Features.JoiningReasons.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.JoiningReasons.Handlers.Queries
{

    public class GetJoiningReasonListByTraineeRequestHandler : IRequestHandler<GetJoiningReasonListByTraineeRequest, List<JoiningReasonDto>>
    {
        private readonly IMapper _mapper; 
        private readonly ISchoolManagementRepository<JoiningReason> _JoiningReasonRepository;
        public GetJoiningReasonListByTraineeRequestHandler(ISchoolManagementRepository<JoiningReason> JoiningReasonRepository, IMapper mapper)
        {
            _JoiningReasonRepository = JoiningReasonRepository;
            _mapper = mapper;
        }
        public async Task<List<JoiningReasonDto>> Handle(GetJoiningReasonListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var JoiningReason = _JoiningReasonRepository.FilterWithInclude(x =>x.TraineeId == request.Traineeid, "ReasonType");
            return _mapper.Map<List<JoiningReasonDto>>(JoiningReason);
        }
    }
}
