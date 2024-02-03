using AutoMapper;
using SchoolManagement.Application.DTOs.BnaCurriculumUpdate;
using SchoolManagement.Application.Features.BnaCurriculumUpdates.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaCurriculumUpdates.Handlers.Queries
{
    public class GetBnaCurriculumUpdateListRequestHandler : IRequestHandler<GetBnaCurriculumUpdateListRequest, PagedResult<BnaCurriculumUpdateDto>>
    {

        private readonly ISchoolManagementRepository<BnaCurriculumUpdate> _BnaCurriculumUpdateRepository;

        private readonly IMapper _mapper;

        public GetBnaCurriculumUpdateListRequestHandler(ISchoolManagementRepository<BnaCurriculumUpdate> BnaCurriculumUpdateRepository, IMapper mapper)
        {
            _BnaCurriculumUpdateRepository = BnaCurriculumUpdateRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaCurriculumUpdateDto>> Handle(GetBnaCurriculumUpdateListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BnaCurriculumUpdate> BnaCurriculumUpdates = _BnaCurriculumUpdateRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText), "BnaBatch", "BnaCurriculumType", "BnaSemester");
            var totalCount = BnaCurriculumUpdates.Count();
            BnaCurriculumUpdates = BnaCurriculumUpdates.OrderByDescending(x => x.BnaCurriculumUpdateId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaCurriculumUpdateDtos = _mapper.Map<List<BnaCurriculumUpdateDto>>(BnaCurriculumUpdates);
            var result = new PagedResult<BnaCurriculumUpdateDto>(BnaCurriculumUpdateDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
