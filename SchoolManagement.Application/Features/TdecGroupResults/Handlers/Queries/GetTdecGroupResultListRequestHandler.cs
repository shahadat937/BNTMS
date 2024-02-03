using SchoolManagement.Application.Features.TdecGroupResults.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TdecGroupResult;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TdecGroupResults.Handlers.Queries
{
    public class GetTdecGroupResultListRequestHandler : IRequestHandler<GetTdecGroupResultListRequest, PagedResult<TdecGroupResultDto>>
    {

        private readonly ISchoolManagementRepository<TdecGroupResult> _TdecGroupResultRepository;

        private readonly IMapper _mapper;

        public GetTdecGroupResultListRequestHandler(ISchoolManagementRepository<TdecGroupResult> TdecGroupResultRepository, IMapper mapper)
        {
            _TdecGroupResultRepository = TdecGroupResultRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TdecGroupResultDto>> Handle(GetTdecGroupResultListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<TdecGroupResult> TdecGroupResults = _TdecGroupResultRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText));
            var totalCount = TdecGroupResults.Count();
            TdecGroupResults = TdecGroupResults.OrderByDescending(x => x.TdecGroupResultId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TdecGroupResultDtos = _mapper.Map<List<TdecGroupResultDto>>(TdecGroupResults);
            var result = new PagedResult<TdecGroupResultDto>(TdecGroupResultDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
