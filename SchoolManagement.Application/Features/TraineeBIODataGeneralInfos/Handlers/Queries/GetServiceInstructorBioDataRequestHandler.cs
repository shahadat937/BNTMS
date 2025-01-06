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
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            //if (validationResult.IsValid == false)
            //    throw new ValidationException(validationResult);

            var spQuery = String.Format("exec [spGetServiceInstructorBioDataGeneralInfo] {0}, {1}", request.BranchId?? "NULL", request.QueryParams.SearchText?? "NULL");

            DataTable dataTable = _TraineeBioDataGeneralInfoRepository.ExecWithSqlQuery(spQuery);


            return dataTable;
        }
    }
}
