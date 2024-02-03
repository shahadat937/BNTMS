using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.IndividualBulletin;
using SchoolManagement.Application.Features.IndividualBulletins.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IndividualBulletins.Handlers.Queries
{
    public class GetIndividualBulletinListRequestHandler : IRequestHandler<GetIndividualBulletinListRequest, PagedResult<IndividualBulletinDto>>
    {

        private readonly ISchoolManagementRepository<IndividualBulletin> _IndividualBulletinRepository;

        private readonly IMapper _mapper;

        public GetIndividualBulletinListRequestHandler(ISchoolManagementRepository<IndividualBulletin> IndividualBulletinRepository, IMapper mapper)
        {
            _IndividualBulletinRepository = IndividualBulletinRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<IndividualBulletinDto>> Handle(GetIndividualBulletinListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<IndividualBulletin> IndividualBulletines = _IndividualBulletinRepository.FilterWithInclude(x => (x.BulletinDetails.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = IndividualBulletines.Count();
            IndividualBulletines = IndividualBulletines.OrderBy(x => x.Status).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var IndividualBulletinDtos = _mapper.Map<List<IndividualBulletinDto>>(IndividualBulletines);
            var result = new PagedResult<IndividualBulletinDto>(IndividualBulletinDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
