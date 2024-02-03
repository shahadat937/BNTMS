using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.Features.ClassRoutines.Requests;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
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

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetClassRoutineListRequestHandler : IRequestHandler<GetClassRoutineListRequest, PagedResult<ClassRoutineDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ClassRoutine> _ClassRoutineRepository;

        private readonly IMapper _mapper;

        public GetClassRoutineListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ClassRoutine> ClassRoutineRepository, IMapper mapper)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ClassRoutineDto>> Handle(GetClassRoutineListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ClassRoutine> ClassRoutines = _ClassRoutineRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText), "ClassPeriod", "BaseSchoolName", "CourseName", "CourseDuration", "BnaSubjectName", "ClassType", "CourseModule");
            var totalCount = ClassRoutines.Count();
            ClassRoutines = ClassRoutines.OrderByDescending(x => x.ClassRoutineId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ClassRoutineDtos = _mapper.Map<List<ClassRoutineDto>>(ClassRoutines);
            var result = new PagedResult<ClassRoutineDto>(ClassRoutineDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
