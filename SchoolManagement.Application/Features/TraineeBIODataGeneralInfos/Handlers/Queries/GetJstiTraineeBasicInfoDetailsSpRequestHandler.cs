using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries
{
    public class GetJstiTraineeBasicInfoDetailsSpRequestHandler : IRequestHandler<GetJstiTraineeBasicInfoDetailsSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _traineeBioDataGeneralInfoRepository;

        private readonly IMapper _mapper;

        public GetJstiTraineeBasicInfoDetailsSpRequestHandler(ISchoolManagementRepository<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfoRepository, IMapper mapper)
        {
            _traineeBioDataGeneralInfoRepository = traineeBioDataGeneralInfoRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetJstiTraineeBasicInfoDetailsSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetJstiTraineeBasicInfoDetails] {0}", request.TraineeId);
            
            DataTable dataTable = _traineeBioDataGeneralInfoRepository.ExecWithSqlQuery(spQuery);
            return dataTable;

        }
    }
}
