using AutoMapper;
using SchoolManagement.Application.DTOs.NewEntryEvaluation;
using SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.NewEntryEvaluations.Handlers.Queries   
{
    public class GetNewEntryEvaluationListBySchoolAndCourseIdRequestHandler : IRequestHandler<GetNewEntryEvaluationListBySchoolAndCourseIdRequest, List<NewEntryEvaluationDto>>
    {

        private readonly ISchoolManagementRepository<NewEntryEvaluation> _NewEntryEvaluationRepository;

        private readonly IMapper _mapper;

        public GetNewEntryEvaluationListBySchoolAndCourseIdRequestHandler(ISchoolManagementRepository<NewEntryEvaluation> NewEntryEvaluationRepository, IMapper mapper)
        {
            _NewEntryEvaluationRepository = NewEntryEvaluationRepository;
            _mapper = mapper;
        }

        public async Task<List<NewEntryEvaluationDto>> Handle(GetNewEntryEvaluationListBySchoolAndCourseIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<NewEntryEvaluation> NewEntryEvaluations = _NewEntryEvaluationRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId , "Trainee.Rank").OrderBy(x => x.NewEntryEvaluationId);

            var NewEntryEvaluationDtos = _mapper.Map<List<NewEntryEvaluationDto>>(NewEntryEvaluations);

            return NewEntryEvaluationDtos;
        }
    }
}
