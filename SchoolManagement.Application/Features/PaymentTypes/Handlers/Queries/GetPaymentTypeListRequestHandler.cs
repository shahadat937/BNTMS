using SchoolManagement.Application.Features.PaymentTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PaymentType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;


namespace SchoolManagement.Application.Features.PaymentTypes.Handlers.Queries
{
    public class GetPaymentTypeListRequestHandler : IRequestHandler<GetPaymentTypeListRequest, PagedResult<PaymentTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.PaymentType> _PaymentTypeRepository;

        private readonly IMapper _mapper;

        public GetPaymentTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.PaymentType> PaymentTypeRepository, IMapper mapper)
        {
            _PaymentTypeRepository = PaymentTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PaymentTypeDto>> Handle(GetPaymentTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.PaymentType> PaymentTypes = _PaymentTypeRepository.FilterWithInclude(x => (x.PaymentTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = PaymentTypes.Count();
            PaymentTypes = PaymentTypes.OrderByDescending(x => x.PaymentTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var PaymentTypeDtos = _mapper.Map<List<PaymentTypeDto>>(PaymentTypes);
            var result = new PagedResult<PaymentTypeDto>(PaymentTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
