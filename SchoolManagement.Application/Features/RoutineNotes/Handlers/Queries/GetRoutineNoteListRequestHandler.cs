using SchoolManagement.Application.Features.RoutineNotes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.RoutineNote;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RoutineNotes.Handlers.Queries
{
    public class GetRoutineNoteListRequestHandler : IRequestHandler<GetRoutineNoteListRequest, PagedResult<RoutineNoteDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.RoutineNote> _RoutineNoteRepository;

        private readonly IMapper _mapper;

        public GetRoutineNoteListRequestHandler(ISchoolManagementRepository<RoutineNote> RoutineNoteRepository, IMapper mapper)
        {
            _RoutineNoteRepository = RoutineNoteRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<RoutineNoteDto>> Handle(GetRoutineNoteListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<RoutineNote> RoutineNotes = _RoutineNoteRepository.FilterWithInclude(x => (x.CourseName.Course.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseName", "BnaSubjectName", "CourseDuration", "ClassRoutine.ClassPeriod");
            var totalCount = RoutineNotes.Count();
            RoutineNotes = RoutineNotes.OrderByDescending(x => x.RoutineNoteId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var RoutineNoteDtos = _mapper.Map<List<RoutineNoteDto>>(RoutineNotes);
            var result = new PagedResult<RoutineNoteDto>(RoutineNoteDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
