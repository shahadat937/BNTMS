using SchoolManagement.Application.Features.TdecQuestionNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TdecQuestionName;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;


namespace SchoolManagement.Application.Features.TdecQuestionNames.Handlers.Queries
{
    public class GetTdecQuestionNameListRequestHandler : IRequestHandler<GetTdecQuestionNameListRequest, PagedResult<TdecQuestionNameDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TdecQuestionName> _TdecQuestionNameRepository;

        private readonly IMapper _mapper;

        public GetTdecQuestionNameListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TdecQuestionName> TdecQuestionNameRepository, IMapper mapper)
        {
            _TdecQuestionNameRepository = TdecQuestionNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TdecQuestionNameDto>> Handle(GetTdecQuestionNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TdecQuestionName> TdecQuestionNames = _TdecQuestionNameRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = TdecQuestionNames.Count();
            TdecQuestionNames = TdecQuestionNames.OrderByDescending(x => x.TdecQuestionNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TdecQuestionNameDtos = _mapper.Map<List<TdecQuestionNameDto>>(TdecQuestionNames);
            var result = new PagedResult<TdecQuestionNameDto>(TdecQuestionNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
