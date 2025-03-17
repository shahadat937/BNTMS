
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ErrorLog;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ErrorLogs.Requests.Queries;


namespace SchoolManagement.Application.Features.ErrorLog.Handlers.Queries
{
    public class GetErrorLogListRequestHandler : IRequestHandler<GetErrorLogListRequest, PagedResult<ErrorLogDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ErrorLog> _ErrorLogRepository;

        private readonly IMapper _mapper;

        public GetErrorLogListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ErrorLog> ErrorLogRepository, IMapper mapper)
        {
            _ErrorLogRepository = ErrorLogRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ErrorLogDto>> Handle(GetErrorLogListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ErrorLog> UTOfficerCategories = _ErrorLogRepository.FilterWithInclude(x => true);
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ErrorLogId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ErrorLogDtos = _mapper.Map<List<ErrorLogDto>>(UTOfficerCategories);
            var result = new PagedResult<ErrorLogDto>(ErrorLogDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
