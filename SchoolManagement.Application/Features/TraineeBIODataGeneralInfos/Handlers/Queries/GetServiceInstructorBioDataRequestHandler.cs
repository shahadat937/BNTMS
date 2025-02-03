using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using MediatR;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Data;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries
{
    public class GetServiceInstructorBioDataRequestHandler : IRequestHandler<GetServiceInstructorBioDataRequest, object>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;

        private readonly IMapper _mapper;

        public GetServiceInstructorBioDataRequestHandler (ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository, IMapper mapper)
        {
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetServiceInstructorBioDataRequest request, CancellationToken cancellationToken)
        {
            var branchId = request.BranchId?.ToString() ?? "NULL";
            var searchText = string.IsNullOrEmpty(request.QueryParams?.SearchText)
                             ? "NULL"
                             : $"'{request.QueryParams.SearchText.Replace("'", "''")}'";

            var spQuery = $"exec [spGetServiceInstructorBioDataGeneralInfo] {branchId}, {searchText}";

            DataTable dataTable = _TraineeBioDataGeneralInfoRepository.ExecWithSqlQuery(spQuery);

            return dataTable;
        }
    }
}
