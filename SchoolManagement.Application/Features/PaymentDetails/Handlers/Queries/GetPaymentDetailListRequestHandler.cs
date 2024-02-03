using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.PaymentDetail;
using SchoolManagement.Application.Features.PaymentDetails.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.PaymentDetails.Handler.Queries
{
    public class GetPaymentDetailListRequestHandler : IRequestHandler<GetPaymentDetailListRequest, PagedResult<PaymentDetailDto>>
    { 

        private readonly ISchoolManagementRepository<PaymentDetail> _PaymentDetailRepository;   

        private readonly IMapper _mapper;  

        public GetPaymentDetailListRequestHandler(ISchoolManagementRepository<PaymentDetail> PaymentDetailRepository, IMapper mapper)
        {
            _PaymentDetailRepository = PaymentDetailRepository; 
            _mapper = mapper; 
        }

        public async Task<PagedResult<PaymentDetailDto>> Handle(GetPaymentDetailListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<PaymentDetail> PaymentDetails = _PaymentDetailRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText));
            var totalCount = PaymentDetails.Count();
            PaymentDetails = PaymentDetails.OrderByDescending(x => x.PaymentDetailId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
             
            var PaymentDetailsDtos = _mapper.Map<List<PaymentDetailDto>>(PaymentDetails); 
            var result = new PagedResult<PaymentDetailDto>(PaymentDetailsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
