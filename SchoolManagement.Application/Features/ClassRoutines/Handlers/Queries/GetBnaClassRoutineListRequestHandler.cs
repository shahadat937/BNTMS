using AutoMapper;
using MediatR;
using Microsoft.VisualBasic;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetBnaClassRoutineListRequestHandler : IRequestHandler<GetBnaClassRoutineListRequest, PagedResult<ClassRoutineDto>>
    {
        private readonly ISchoolManagementRepository<BnaClassRoutine> _BnaClassRoutineRepository;
        private readonly IMapper _mapper;
        public GetBnaClassRoutineListRequestHandler(ISchoolManagementRepository<BnaClassRoutine> BnaClassRoutineRepository, IMapper mapper)
        {
            _BnaClassRoutineRepository = BnaClassRoutineRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ClassRoutineDto>> Handle(GetBnaClassRoutineListRequest request, CancellationToken cancellationToken)
        {
            List<int> bnaClassRoutineIds = new List<int>();
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            IQueryable<BnaClassRoutine> bnaClassRoutines = _BnaClassRoutineRepository.Where(x => true);

            foreach (var item in bnaClassRoutines)
            {
                string[] semesterIdsString = item.BnaSemesterId.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
                int[] bnaSemesterIds = semesterIdsString.Select(int.Parse).ToArray();
                foreach (var semesterId in bnaSemesterIds)
                {
                    if (semesterId == request.BnaSemesterId)
                    {
                        bnaClassRoutineIds.Add(item.BnaClassRoutineId);
                    }
                }
            }



            var bnaClassRoutineDtos = _mapper.Map<List<ClassRoutineDto>>(bnaClassRoutines);
            var totalCount = bnaClassRoutines.Count();
            var result = new PagedResult<ClassRoutineDto>(bnaClassRoutineDtos, totalCount,
                request.QueryParams.PageNumber,
                request.QueryParams.PageSize);

            return result;
        }
    }
}
