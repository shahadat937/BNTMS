using SchoolManagement.Application.Features.BnaClassTests.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassTest;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaClassTests.Handlers.Queries
{
    public class GetBnaClassTestListRequestHandler : IRequestHandler<GetBnaClassTestListRequest, PagedResult<BnaClassTestDto>>
    {

        private readonly ISchoolManagementRepository<BnaClassTest> _BnaClassTestRepository;

        private readonly IMapper _mapper;

        public GetBnaClassTestListRequestHandler(ISchoolManagementRepository<BnaClassTest> BnaClassTestRepository, IMapper mapper)
        {
            _BnaClassTestRepository = BnaClassTestRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaClassTestDto>> Handle(GetBnaClassTestListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BnaClassTest> BnaClassTest = _BnaClassTestRepository.FilterWithInclude(x => (x.Percentage.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "BnaClassTestType", "BnaSemester", "BnaSubjectCurriculum", "BnaSubjectName", "SubjectCategory");
            var totalCount = BnaClassTest.Count();
            BnaClassTest = BnaClassTest.OrderByDescending(x => x.BnaClassTestId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaClassTestDtos = _mapper.Map<List<BnaClassTestDto>>(BnaClassTest);
            var result = new PagedResult<BnaClassTestDto>(BnaClassTestDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
