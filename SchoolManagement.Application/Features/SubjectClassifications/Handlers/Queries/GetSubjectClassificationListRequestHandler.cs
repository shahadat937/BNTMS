using AutoMapper;
using SchoolManagement.Application.Features.SubjectClassifications.Requests.Queries;
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
using SchoolManagement.Application.DTOs.SubjectClassifications;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SubjectClassifications.Handlers.Queries
{
    public class GetSubjectClassificationListRequestHandler : IRequestHandler<GetSubjectClassificationListRequest, PagedResult<SubjectClassificationDto>>
    {

        private readonly ISchoolManagementRepository<SubjectClassification> _SubjectClassificationRepository;

        private readonly IMapper _mapper;

        public GetSubjectClassificationListRequestHandler(ISchoolManagementRepository<SubjectClassification> SubjectClassificationRepository, IMapper mapper)
        {
            _SubjectClassificationRepository = SubjectClassificationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SubjectClassificationDto>> Handle(GetSubjectClassificationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SubjectClassification> SubjectClassifications = _SubjectClassificationRepository.FilterWithInclude(x => (x.SubjectClassificationName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = SubjectClassifications.Count();
            SubjectClassifications = SubjectClassifications.OrderByDescending(x => x.SubjectClassificationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SubjectClassificationDtos = _mapper.Map<List<SubjectClassificationDto>>(SubjectClassifications);
            var result = new PagedResult<SubjectClassificationDto>(SubjectClassificationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
