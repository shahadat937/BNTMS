using AutoMapper;
using SchoolManagement.Application.DTOs.TdecQuestionName;
using SchoolManagement.Application.Features.TdecQuestionNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;

namespace SchoolManagement.Application.Features.TdecQuestionNames.Handlers.Queries
{
    public class GetTdecListRequestHandler : IRequestHandler<GetTdecListRequest, List<TdecQuestionNameDto>>
    {

        private readonly ISchoolManagementRepository<TdecQuestionName> _TdecQuestionNameRepository;

        private readonly IMapper _mapper;

        public GetTdecListRequestHandler(ISchoolManagementRepository<TdecQuestionName> TdecQuestionNameRepository, IMapper mapper)
        {
            _TdecQuestionNameRepository = TdecQuestionNameRepository;
            _mapper = mapper;
        }

        public async Task<List<TdecQuestionNameDto>> Handle(GetTdecListRequest request, CancellationToken cancellationToken)
        {
            var TdecQuestionNameDtos = new List<TdecQuestionNameDto>();
            if (request.BaseSchoolNameId == 0)
            {
                var TdecQuestionNames = _TdecQuestionNameRepository.FilterWithInclude(x => x.IsActive && x.BaseSchoolNameId == null);
                //var TdecQuestionNames = _TdecQuestionNameRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.TdecQuestionNameId);

                TdecQuestionNameDtos = _mapper.Map<List<TdecQuestionNameDto>>(TdecQuestionNames);
            }
            else
            {
                var TdecQuestionNames = _TdecQuestionNameRepository.FilterWithInclude(x => x.IsActive && x.BaseSchoolNameId == request.BaseSchoolNameId);
                //var TdecQuestionNames = _TdecQuestionNameRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.TdecQuestionNameId);

                TdecQuestionNameDtos = _mapper.Map<List<TdecQuestionNameDto>>(TdecQuestionNames);
            }


            return TdecQuestionNameDtos;
        }
    }
}
