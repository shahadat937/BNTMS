using AutoMapper;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName;
using SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Handlers.Queries
{
    public class GetGuestSpeakerListRequestHandler : IRequestHandler<GetGuestSpeakerListRequest, PagedResult<GuestSpeakerQuestionNameDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerQuestionName> _GuestSpeakerQuestionNameRepository;

        private readonly IMapper _mapper;

        public GetGuestSpeakerListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GuestSpeakerQuestionName> GuestSpeakerQuestionNameRepository, IMapper mapper)
        {
            _GuestSpeakerQuestionNameRepository = GuestSpeakerQuestionNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GuestSpeakerQuestionNameDto>> Handle(GetGuestSpeakerListRequest request, CancellationToken cancellationToken)
        {
            //if(request.BaseSchoolNameId == 0)
            //{
            //    request.BaseSchoolNameId = null;
            //}
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var GuestSpeakerQuestionNameDtos = new List<GuestSpeakerQuestionNameDto>();
            var totalCount = 0;

            if (request.BaseSchoolNameId == 0)
            {
                IQueryable<SchoolManagement.Domain.GuestSpeakerQuestionName> GuestSpeakerQuestionNames = _GuestSpeakerQuestionNameRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText))).Where(x => x.BaseSchoolNameId == null);
                totalCount = GuestSpeakerQuestionNames.Count();
                GuestSpeakerQuestionNames = GuestSpeakerQuestionNames.OrderByDescending(x => x.GuestSpeakerQuestionNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

                GuestSpeakerQuestionNameDtos = _mapper.Map<List<GuestSpeakerQuestionNameDto>>(GuestSpeakerQuestionNames);
                // var result = new PagedResult<GuestSpeakerQuestionNameDto>(GuestSpeakerQuestionNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            }

            else
            {
                IQueryable<SchoolManagement.Domain.GuestSpeakerQuestionName> GuestSpeakerQuestionNames = _GuestSpeakerQuestionNameRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText))).Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId);
                totalCount = GuestSpeakerQuestionNames.Count();
                GuestSpeakerQuestionNames = GuestSpeakerQuestionNames.OrderByDescending(x => x.GuestSpeakerQuestionNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

                GuestSpeakerQuestionNameDtos = _mapper.Map<List<GuestSpeakerQuestionNameDto>>(GuestSpeakerQuestionNames);

            }

            var result = new PagedResult<GuestSpeakerQuestionNameDto>(GuestSpeakerQuestionNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
    //public class GetGuestSpeakerListRequestHandler : IRequestHandler<GetGuestSpeakerListRequest, List<GuestSpeakerQuestionNameDto>>
    //{

    //    private readonly ISchoolManagementRepository<GuestSpeakerQuestionName> _GuestSpeakerQuestionNameRepository;

    //    private readonly IMapper _mapper;

    //    public GetGuestSpeakerListRequestHandler(ISchoolManagementRepository<GuestSpeakerQuestionName> GuestSpeakerQuestionNameRepository, IMapper mapper)
    //    {
    //        _GuestSpeakerQuestionNameRepository = GuestSpeakerQuestionNameRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task<List<GuestSpeakerQuestionNameDto>> Handle(GetGuestSpeakerListRequest request, CancellationToken cancellationToken)
    //    {
    //        var GuestSpeakerQuestionNameDtos = new List<GuestSpeakerQuestionNameDto>();
    //        if (request.BaseSchoolNameId == 0)
    //        {
    //            var GuestSpeakerQuestionNames = _GuestSpeakerQuestionNameRepository.FilterWithInclude(x => x.IsActive && x.BaseSchoolNameId == null);
    //            //var GuestSpeakerQuestionNames = _GuestSpeakerQuestionNameRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.GuestSpeakerQuestionNameId);

    //            GuestSpeakerQuestionNameDtos = _mapper.Map<List<GuestSpeakerQuestionNameDto>>(GuestSpeakerQuestionNames);
    //        }
    //        else
    //        {
    //            var GuestSpeakerQuestionNames = _GuestSpeakerQuestionNameRepository.FilterWithInclude(x => x.IsActive && x.BaseSchoolNameId == request.BaseSchoolNameId);
    //            //var GuestSpeakerQuestionNames = _GuestSpeakerQuestionNameRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.GuestSpeakerQuestionNameId);

    //            GuestSpeakerQuestionNameDtos = _mapper.Map<List<GuestSpeakerQuestionNameDto>>(GuestSpeakerQuestionNames);
    //        }


    //        return GuestSpeakerQuestionNameDtos;
    //    }
    //}
}
