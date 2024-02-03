using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaExamMark;
using SchoolManagement.Application.Features.BnaExamMarks.Requests;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Queries
{
    public class GetBnaExamMarkListRequestHandler : IRequestHandler<GetBnaExamMarkListRequest, PagedResult<BnaExamMarkDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaExamMark> _BnaExamMarkRepository;

        private readonly IMapper _mapper;

        public GetBnaExamMarkListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaExamMark> BnaExamMarkRepository, IMapper mapper)
        {
            _BnaExamMarkRepository = BnaExamMarkRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaExamMarkDto>> Handle(GetBnaExamMarkListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.BnaExamMark> BnaExamMarks = _BnaExamMarkRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText));
            var totalCount = BnaExamMarks.Count();
            BnaExamMarks = BnaExamMarks.OrderByDescending(x => x.BnaExamMarkId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaExamMarkDtos = _mapper.Map<List<BnaExamMarkDto>>(BnaExamMarks);
            var result = new PagedResult<BnaExamMarkDto>(BnaExamMarkDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;

             
        }
    }
}
