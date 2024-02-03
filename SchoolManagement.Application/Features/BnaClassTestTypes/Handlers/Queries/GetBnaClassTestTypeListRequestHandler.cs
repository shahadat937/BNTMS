using SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassTestType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaClassTestTypes.Handlers.Queries
{
    public class GetBnaClassTestTypeListRequestHandler : IRequestHandler<GetBnaClassTestTypeListRequest, PagedResult<BnaClassTestTypeDto>>
    {

        private readonly ISchoolManagementRepository<BnaClassTestType> _BnaClassTestTypeRepository;

        private readonly IMapper _mapper;

        public GetBnaClassTestTypeListRequestHandler(ISchoolManagementRepository<BnaClassTestType> BnaClassTestTypeRepository, IMapper mapper)
        {
            _BnaClassTestTypeRepository = BnaClassTestTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaClassTestTypeDto>> Handle(GetBnaClassTestTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BnaClassTestType> BnaClassTestType = _BnaClassTestTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BnaClassTestType.Count();
            BnaClassTestType = BnaClassTestType.OrderByDescending(x => x.BnaClassTestTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaClassTestTypeDtos = _mapper.Map<List<BnaClassTestTypeDto>>(BnaClassTestType);
            var result = new PagedResult<BnaClassTestTypeDto>(BnaClassTestTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
