using SchoolManagement.Application.Features.ExamMarkRemark.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamMarkRemarks;
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


namespace SchoolManagement.Application.Features.ExamMarkRemark.Handlers.Queries
{
    public class GetExamMarkRemarkListRequestHandler : IRequestHandler<GetExamMarkRemarkListRequest, PagedResult<ExamMarkRemarkDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ExamMarkRemarks> _ExamMarkRemarkRepository;

        private readonly IMapper _mapper;

        public GetExamMarkRemarkListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ExamMarkRemarks> ExamMarkRemarkRepository, IMapper mapper)
        {
            _ExamMarkRemarkRepository = ExamMarkRemarkRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ExamMarkRemarkDto>> Handle(GetExamMarkRemarkListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ExamMarkRemarks> ExamMarkRemarks = _ExamMarkRemarkRepository.FilterWithInclude(x => (x.MarkRemark.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ExamMarkRemarks.Count();
            ExamMarkRemarks = ExamMarkRemarks.OrderByDescending(x => x.ExamMarkRemarksId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ExamMarkRemarkDtos = _mapper.Map<List<ExamMarkRemarkDto>>(ExamMarkRemarks);
            var result = new PagedResult<ExamMarkRemarkDto>(ExamMarkRemarkDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
