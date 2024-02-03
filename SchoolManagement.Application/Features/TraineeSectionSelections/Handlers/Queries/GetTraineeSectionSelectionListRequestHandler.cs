using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeSectionSelection;
using SchoolManagement.Application.Features.TraineeSectionSelections.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.TraineeSectionSelections.Handlers.Queries
{
    public class GetTraineeSectionSelectionListRequestHandler : IRequestHandler<GetTraineeSectionSelectionListRequest, PagedResult<TraineeSectionSelectionDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeSectionSelection> _TraineeSectionSelectionRepository;

        private readonly IMapper _mapper;

        public GetTraineeSectionSelectionListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeSectionSelection> TraineeSectionSelectionRepository, IMapper mapper)
        {
            _TraineeSectionSelectionRepository = TraineeSectionSelectionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineeSectionSelectionDto>> Handle(GetTraineeSectionSelectionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TraineeSectionSelection> TraineeSectionSelections = _TraineeSectionSelectionRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "BnaBatch", "BnaClassSectionSelection", "PreviewsSection", "BnaSemester");
            var totalCount = TraineeSectionSelections.Count();
            TraineeSectionSelections = TraineeSectionSelections.OrderByDescending(x => x.TraineeSectionSelectionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TraineeSectionSelectionDtos = _mapper.Map<List<TraineeSectionSelectionDto>>(TraineeSectionSelections);
            var result = new PagedResult<TraineeSectionSelectionDto>(TraineeSectionSelectionDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
