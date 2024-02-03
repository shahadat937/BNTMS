using SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculum;
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
using SchoolManagement.Application.DTOs.BnaSubjectCurriculums;

namespace SchoolManagement.Application.Features.BnaSubjectCurriculums.Handlers.Queries
{
    public class GetBnaSubjectCurriculumListRequestHandler : IRequestHandler<GetBnaSubjectCurriculumListRequest, PagedResult<BnaSubjectCurriculumDto>>
    {

        private readonly ISchoolManagementRepository<BnaSubjectCurriculum> _BnaSubjectCurriculumRepository;

        private readonly IMapper _mapper;

        public GetBnaSubjectCurriculumListRequestHandler(ISchoolManagementRepository<BnaSubjectCurriculum> BnaSubjectCurriculumRepository, IMapper mapper)
        {
            _BnaSubjectCurriculumRepository = BnaSubjectCurriculumRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaSubjectCurriculumDto>> Handle(GetBnaSubjectCurriculumListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 

            IQueryable<BnaSubjectCurriculum> BnaSubjectCurriculums = _BnaSubjectCurriculumRepository.FilterWithInclude(x => (x.SubjectCurriculumName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BnaSubjectCurriculums.Count();
            BnaSubjectCurriculums = BnaSubjectCurriculums.OrderByDescending(x => x.BnaSubjectCurriculumId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaSubjectCurriculumDtos = _mapper.Map<List<BnaSubjectCurriculumDto>>(BnaSubjectCurriculums);
            var result = new PagedResult<BnaSubjectCurriculumDto>(BnaSubjectCurriculumDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
