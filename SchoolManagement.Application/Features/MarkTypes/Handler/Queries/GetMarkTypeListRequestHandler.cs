using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MarkType;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System.ComponentModel.DataAnnotations;
using SchoolManagement.Application.Features.MarkTypes.Requests.Queries;

namespace SchoolManagement.Application.Features.MarkTypes.Handler.Queries
{
    public class GetMarkTypeListRequestHandler : IRequestHandler<GetMarkTypeListRequest, PagedResult<MarkTypeDto>>
    { 

        private readonly ISchoolManagementRepository<MarkType> _MarkTypeRepository;  

        private readonly IMapper _mapper;

        public GetMarkTypeListRequestHandler(ISchoolManagementRepository<MarkType> MarkTypeRepository, IMapper mapper)
        {
            _MarkTypeRepository = MarkTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MarkTypeDto>> Handle(GetMarkTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false) 
                throw new ValidationException(validationResult.ToString());

            IQueryable<MarkType> MarkType = _MarkTypeRepository.FilterWithInclude(x => (x.TypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = MarkType.Count();
            MarkType = MarkType.OrderByDescending(x => x.MarkTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MarkTypeDtos = _mapper.Map<List<MarkTypeDto>>(MarkType);
            var result = new PagedResult<MarkTypeDto>(MarkTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
