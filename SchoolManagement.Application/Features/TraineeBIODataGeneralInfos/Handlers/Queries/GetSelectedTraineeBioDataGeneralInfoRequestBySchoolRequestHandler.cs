using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Handlers.Queries
{
    public class GetSelectedTraineeBioDataGeneralInfoRequestBySchoolRequestHandler : IRequestHandler<GetSelectedTraineeBioDataGeneralInfoRequestBySchoolRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;
        private readonly ISchoolManagementRepository<AspNetUsers> _aspNetUsersRepository;

        public GetSelectedTraineeBioDataGeneralInfoRequestBySchoolRequestHandler(
            ISchoolManagementRepository<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository,
            ISchoolManagementRepository<AspNetUsers> aspNetUsersRepository
            )
        {
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
            _aspNetUsersRepository = aspNetUsersRepository;
        }

        public async Task<object> Handle(GetSelectedTraineeBioDataGeneralInfoRequestBySchoolRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetServiceInstructorInstructorsBySchool] {0}", request.BranchId);

            DataTable dataTable = _TraineeBioDataGeneralInfoRepository.ExecWithSqlQuery(spQuery);

           

            return dataTable;

        }

    }
}
