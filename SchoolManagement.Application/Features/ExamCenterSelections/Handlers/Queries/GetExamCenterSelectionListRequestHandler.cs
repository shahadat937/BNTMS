using SchoolManagement.Application.Features.ExamCenterSelections.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ExamCenterSelection;
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

namespace SchoolManagement.Application.Features.ExamCenterSelections.Handlers.Queries
{
    public class GetExamCenterSelectionListRequestHandler : IRequestHandler<GetExamCenterSelectionListRequest, PagedResult<ExamCenterSelectionDto>>
    {

        private readonly ISchoolManagementRepository<ExamCenterSelection> _ExamCenterSelectionRepository;

        private readonly IMapper _mapper;

        public GetExamCenterSelectionListRequestHandler(ISchoolManagementRepository<ExamCenterSelection> ExamCenterSelectionRepository, IMapper mapper)
        {
            _ExamCenterSelectionRepository = ExamCenterSelectionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ExamCenterSelectionDto>> Handle(GetExamCenterSelectionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ExamCenterSelection> ExamCenterSelections = _ExamCenterSelectionRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "ExamCenter");
            var totalCount = ExamCenterSelections.Count();
            ExamCenterSelections = ExamCenterSelections.OrderByDescending(x => x.ExamCenterSelectionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ExamCenterSelectionDtos = _mapper.Map<List<ExamCenterSelectionDto>>(ExamCenterSelections);
            var result = new PagedResult<ExamCenterSelectionDto>(ExamCenterSelectionDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
