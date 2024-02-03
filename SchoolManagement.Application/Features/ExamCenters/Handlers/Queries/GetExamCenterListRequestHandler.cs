using SchoolManagement.Application.Features.ExamCenters.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamCenter;
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
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ExamCenters.Handlers.Queries
{
    public class GetExamCenterListRequestHandler : IRequestHandler<GetExamCenterListRequest, PagedResult<ExamCenterDto>>
    {

        private readonly ISchoolManagementRepository<ExamCenter> _ExamCenterRepository;

        private readonly IMapper _mapper;

        public GetExamCenterListRequestHandler(ISchoolManagementRepository<ExamCenter> ExamCenterRepository, IMapper mapper)
        {
            _ExamCenterRepository = ExamCenterRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ExamCenterDto>> Handle(GetExamCenterListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ExamCenter> ExamCenters = _ExamCenterRepository.FilterWithInclude(x => (x.ExamCenterName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ExamCenters.Count();
            ExamCenters = ExamCenters.OrderByDescending(x => x.ExamCenterId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ExamCenterDtos = _mapper.Map<List<ExamCenterDto>>(ExamCenters);
            var result = new PagedResult<ExamCenterDto>(ExamCenterDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
