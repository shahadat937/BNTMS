using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetBnaClassRoutineListRequestHandler : IRequestHandler<GetBnaClassRoutineListRequestNew, object>
    {
        private readonly ISchoolManagementRepository<BnaClassRoutine> _BnaClassRoutineRepository;
        private readonly IMapper _mapper;
        public GetBnaClassRoutineListRequestHandler(ISchoolManagementRepository<BnaClassRoutine> BnaClassRoutineRepository, IMapper mapper)
        {
            _BnaClassRoutineRepository = BnaClassRoutineRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBnaClassRoutineListRequestNew request, CancellationToken cancellationToken)
        {
            List<int> bnaSemesterWeekClassRoutineIds = new List<int>();

            ArrayList bnaQueryBnaClassResult = new ArrayList();

            
            IQueryable<BnaClassRoutine> bnaClassRoutines = _BnaClassRoutineRepository.Where(x => true);

            foreach (var item in bnaClassRoutines)
            {
                string[] semesterIdsString = item.BnaSemesterId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int[] bnaSemesterIds = semesterIdsString.Select(int.Parse).ToArray();
                foreach (var semesterId in bnaSemesterIds)
                {
                    if (semesterId == request.BnaSemesterId)
                    {
                        if (item.WeekID == request.WeekID)
                        {
                            bnaSemesterWeekClassRoutineIds.Add(item.BnaClassRoutineId);
                            bnaQueryBnaClassResult.Add(item);
                        }
                    }
                }
            }


            return bnaQueryBnaClassResult;
        }

    }

}
