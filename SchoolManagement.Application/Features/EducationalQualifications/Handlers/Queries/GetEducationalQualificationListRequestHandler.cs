using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.EducationalQualification;
using SchoolManagement.Application.Features.EducationalQualifications.Requests;
using SchoolManagement.Application.Features.EducationalQualifications.Requests.Queries;
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

namespace SchoolManagement.Application.Features.EducationalQualifications.Handlers.Queries
{
    public class GetEducationalQualificationListRequestHandler : IRequestHandler<GetEducationalQualificationListRequest, PagedResult<EducationalQualificationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EducationalQualification> _EducationalQualificationRepository;

        private readonly IMapper _mapper;

        public GetEducationalQualificationListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.EducationalQualification> EducationalQualificationRepository, IMapper mapper)
        {
            _EducationalQualificationRepository = EducationalQualificationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<EducationalQualificationDto>> Handle(GetEducationalQualificationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.EducationalQualification> EducationalQualifications = _EducationalQualificationRepository.FilterWithInclude(x => (x.Subject.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "ExamType", "Board", "Group");
            var totalCount = EducationalQualifications.Count();
            EducationalQualifications = EducationalQualifications.OrderByDescending(x => x.EducationalQualificationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var EducationalQualificationDtos = _mapper.Map<List<EducationalQualificationDto>>(EducationalQualifications);
            var result = new PagedResult<EducationalQualificationDto>(EducationalQualificationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
