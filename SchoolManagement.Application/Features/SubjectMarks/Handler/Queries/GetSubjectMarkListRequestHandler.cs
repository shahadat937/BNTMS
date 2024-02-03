using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SubjectMark;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System.ComponentModel.DataAnnotations;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;

namespace SchoolManagement.Application.Features.SubjectMarks.Handler.Queries
{
    public class GetSubjectMarkListRequestHandler : IRequestHandler<GetSubjectMarkListRequest, PagedResult<SubjectMarkDto>>
    { 

        private readonly ISchoolManagementRepository<SubjectMark> _SubjectMarkRepository;  

        private readonly IMapper _mapper;

        public GetSubjectMarkListRequestHandler(ISchoolManagementRepository<SubjectMark> SubjectMarkRepository, IMapper mapper)
        {
            _SubjectMarkRepository = SubjectMarkRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SubjectMarkDto>> Handle(GetSubjectMarkListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false) 
                throw new ValidationException(validationResult.ToString());

            IQueryable<SubjectMark> SubjectMark = _SubjectMarkRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText), "BaseSchoolName", "BnaSubjectName", "CourseModule", "CourseName", "MarkType");
            var totalCount = SubjectMark.Count();
            SubjectMark = SubjectMark.OrderByDescending(x => x.SubjectMarkId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SubjectMarkDtos = _mapper.Map<List<SubjectMarkDto>>(SubjectMark);
            var result = new PagedResult<SubjectMarkDto>(SubjectMarkDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
