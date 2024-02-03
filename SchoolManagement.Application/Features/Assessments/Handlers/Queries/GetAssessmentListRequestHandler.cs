using SchoolManagement.Application.Features.Assessments.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Assessment;
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


namespace SchoolManagement.Application.Features.Assessments.Handlers.Queries
{
    public class GetAssessmentListRequestHandler : IRequestHandler<GetAssessmentListRequest, PagedResult<AssessmentDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Assessment> _AssessmentRepository;

        private readonly IMapper _mapper;

        public GetAssessmentListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Assessment> AssessmentRepository, IMapper mapper)
        {
            _AssessmentRepository = AssessmentRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AssessmentDto>> Handle(GetAssessmentListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Assessment> Assessments = _AssessmentRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Assessments.Count();
            Assessments = Assessments.OrderByDescending(x => x.AssessmentId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AssessmentDtos = _mapper.Map<List<AssessmentDto>>(Assessments);
            var result = new PagedResult<AssessmentDto>(AssessmentDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
