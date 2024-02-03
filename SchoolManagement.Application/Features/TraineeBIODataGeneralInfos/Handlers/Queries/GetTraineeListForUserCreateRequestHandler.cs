using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using MediatR;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using SchoolManagement.Domain;
using System.Data;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries
{
    public class GetTraineeListForUserCreateRequestHandler : IRequestHandler<GetTraineeListForUserCreateRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _traineeBioDataGeneralInfoRepository;

        private readonly IMapper _mapper;

        public GetTraineeListForUserCreateRequestHandler(ISchoolManagementRepository<TraineeBioDataGeneralInfo> traineeBioDataGeneralInfoRepository, IMapper mapper)
        {
            _traineeBioDataGeneralInfoRepository = traineeBioDataGeneralInfoRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTraineeListForUserCreateRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetTraineeListForUserCreate] '{0}'",request.Pno);

            DataTable dataTable = _traineeBioDataGeneralInfoRepository.ExecWithSqlQuery(spQuery);
            

            return dataTable;

        }
    }
}
