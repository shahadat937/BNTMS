using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries
{
    public class GetTotalTraineeListFromSpRequestHandler : IRequestHandler<GetTotalTraineeListFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _traineeBioDataGeneralInfoRepository;

        private readonly IMapper _mapper;

        public GetTotalTraineeListFromSpRequestHandler(ISchoolManagementRepository<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfoRepository, IMapper mapper)
        {
            _traineeBioDataGeneralInfoRepository = traineeBioDataGeneralInfoRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTotalTraineeListFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetTotalTraineeList] " /*request.CourseTypeId, request.CurrentDate*/);
            
            DataTable dataTable = _traineeBioDataGeneralInfoRepository.ExecWithSqlQuery(spQuery);
            //return dataTable;

            var traineeCount = "";

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                traineeCount = row["column1"].ToString();
            }

            return traineeCount;

        }
    }
}
