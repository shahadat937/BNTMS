using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.RoutineNote;
using SchoolManagement.Application.Features.RoutineNotes.Requests;
using SchoolManagement.Application.Features.RoutineNotes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.RoutineNotes.Handlers.Queries
{
    public class GetRoutineNoteListByBaseSchoolNameIdRequestHandler : IRequestHandler<GetRoutineNoteListByBaseSchoolNameIdRequest, PagedResult<RoutineNoteDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.RoutineNote> _RoutineNoteRepository;

        private readonly IMapper _mapper;

        public GetRoutineNoteListByBaseSchoolNameIdRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.RoutineNote> RoutineNoteRepository, IMapper mapper)
        {
            _RoutineNoteRepository = RoutineNoteRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<RoutineNoteDto>> Handle(GetRoutineNoteListByBaseSchoolNameIdRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.RoutineNote> RoutineNotes = _RoutineNoteRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText), "CourseName", "BnaSubjectName", "CourseDuration", "ClassRoutine.ClassPeriod").Where(x=>x.BaseSchoolNameId==request.BaseSchoolNameId);
            var totalCount = RoutineNotes.Count();
            RoutineNotes = RoutineNotes.OrderByDescending(x => x.RoutineNoteId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var RoutineNoteDtos = _mapper.Map<List<RoutineNoteDto>>(RoutineNotes);
            var result = new PagedResult<RoutineNoteDto>(RoutineNoteDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
