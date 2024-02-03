using AutoMapper;
using SchoolManagement.Application.DTOs.JoiningReasons;
using SchoolManagement.Application.Features.JoiningReasons.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.JoiningReasons.Handlers.Queries
{
    //public class GetJoiningReasonListByTraineeRequestHandler : IRequestHandler<GetJoiningReasonListByTraineeRequest, Unit>


    public class GetJoiningReasonDetailByTraineeRequestHandler : IRequestHandler<GetJoiningReasonDetailByTraineeRequest, JoiningReasonDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<JoiningReason> _JoiningReasonRepository;
        public GetJoiningReasonDetailByTraineeRequestHandler(ISchoolManagementRepository<JoiningReason> JoiningReasonRepository, IMapper mapper)
        {
            _JoiningReasonRepository = JoiningReasonRepository;
            _mapper = mapper;
        }
        //public async Task<JoiningReasonDto> Handle(GetJoiningReasonDetailByTraineeRequest request, CancellationToken cancellationToken)
        //{
        //    var JoiningReason = _JoiningReasonRepository.FilterWithInclude(x =>x.TraineeId == request.Traineeid);
        //    return _mapper.Map<JoiningReasonDto>(JoiningReason);
        //}

        public async Task<JoiningReasonDto> Handle(GetJoiningReasonDetailByTraineeRequest request, CancellationToken cancellationToken)
        {
            var JoiningReason = _JoiningReasonRepository.FinedOneInclude(x => x.TraineeId == request.Traineeid);
            return _mapper.Map<JoiningReasonDto>(JoiningReason);
        }
    }    
}
