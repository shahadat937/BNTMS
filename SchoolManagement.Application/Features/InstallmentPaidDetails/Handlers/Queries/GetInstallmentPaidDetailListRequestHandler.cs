using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.InstallmentPaidDetail;
using SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InstallmentPaidDetails.Handler.Queries
{
    public class GetInstallmentPaidDetailListRequestHandler : IRequestHandler<GetInstallmentPaidDetailListRequest, PagedResult<InstallmentPaidDetailDto>>
    { 

        private readonly ISchoolManagementRepository<InstallmentPaidDetail> _InstallmentPaidDetailRepository;   

        private readonly IMapper _mapper;  

        public GetInstallmentPaidDetailListRequestHandler(ISchoolManagementRepository<InstallmentPaidDetail> InstallmentPaidDetailRepository, IMapper mapper)
        {
            _InstallmentPaidDetailRepository = InstallmentPaidDetailRepository; 
            _mapper = mapper; 
        }

        public async Task<PagedResult<InstallmentPaidDetailDto>> Handle(GetInstallmentPaidDetailListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<InstallmentPaidDetail> InstallmentPaidDetails = _InstallmentPaidDetailRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText));
            var totalCount = InstallmentPaidDetails.Count();
            InstallmentPaidDetails = InstallmentPaidDetails.OrderBy(x => x.PaymentCompletedStatus).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
             
            var InstallmentPaidDetailsDtos = _mapper.Map<List<InstallmentPaidDetailDto>>(InstallmentPaidDetails); 
            var result = new PagedResult<InstallmentPaidDetailDto>(InstallmentPaidDetailsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
