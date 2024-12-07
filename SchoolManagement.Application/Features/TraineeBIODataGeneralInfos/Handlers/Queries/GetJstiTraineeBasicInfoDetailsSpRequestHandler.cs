using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries
{
    public class GetJstiTraineeBasicInfoDetailsSpRequestHandler : IRequestHandler<GetJstiTraineeBasicInfoDetailsSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _traineeBioDataGeneralInfoRepository;

        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public GetJstiTraineeBasicInfoDetailsSpRequestHandler(ISchoolManagementRepository<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfoRepository, IMapper mapper, IConfiguration config)
        {
            _traineeBioDataGeneralInfoRepository = traineeBioDataGeneralInfoRepository;
            _mapper = mapper;
            _config = config;
        }

        public async Task<object> Handle(GetJstiTraineeBasicInfoDetailsSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetJstiTraineeBasicInfoDetails] {0}", request.TraineeId);

            DataTable dataTable = _traineeBioDataGeneralInfoRepository.ExecWithSqlQuery(spQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["BnaPhotoUrl"] != DBNull.Value)
                {
                    string filePath = row["BnaPhotoUrl"].ToString();
                    row["BnaPhotoUrl"] = _config["ApiUrl"] + filePath;
                }
            }

            return dataTable;

        }
    }
}
