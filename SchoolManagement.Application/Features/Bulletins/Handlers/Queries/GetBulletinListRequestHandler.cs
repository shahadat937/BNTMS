using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Bulletin;
using SchoolManagement.Application.Features.Bulletins.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Bulletins.Handlers.Queries
{
    public class GetBulletinListRequestHandler : IRequestHandler<GetBulletinListRequest, PagedResult<BulletinDto>>
    {

        private readonly ISchoolManagementRepository<Bulletin> _BulletinRepository;

        private readonly IMapper _mapper;

        public GetBulletinListRequestHandler(ISchoolManagementRepository<Bulletin> BulletinRepository, IMapper mapper)
        {
            _BulletinRepository = BulletinRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BulletinDto>> Handle(GetBulletinListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Bulletin> Bulletines = _BulletinRepository.FilterWithInclude(x => (x.BuletinDetails.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText) && x.BaseSchoolNameId == request.BaseSchoolNameId), "BaseSchoolName", "CourseName", "CourseDuration");
            var totalCount = Bulletines.Count();
            Bulletines = Bulletines.OrderBy(x => x.Status).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BulletinDtos = _mapper.Map<List<BulletinDto>>(Bulletines);
            var result = new PagedResult<BulletinDto>(BulletinDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
