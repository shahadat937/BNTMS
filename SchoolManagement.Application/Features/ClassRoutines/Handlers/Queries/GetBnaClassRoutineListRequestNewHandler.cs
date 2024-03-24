using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetBnaClassRoutineListRequestNewHandler : IRequestHandler<GetBnaClassRoutineListRequestNew, List<BnaRoutineModel>>
    {
        private readonly ISchoolManagementRepository<BnaClassRoutine> _BnaClassRoutineRepository;
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;
        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;
        
        public GetBnaClassRoutineListRequestNewHandler(ISchoolManagementRepository<BnaClassRoutine> BnaClassRoutineRepository, ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, ISchoolManagementRepository<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository)
        {
            _BnaClassRoutineRepository = BnaClassRoutineRepository;
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
        }

        public async Task<List<BnaRoutineModel>> Handle(GetBnaClassRoutineListRequestNew request, CancellationToken cancellationToken)
        {
            string ExtraCurriculamPeriod;
            string period_1;
            string period_2;
            string period_3;
            string period_4;
            string period_5;
            string period_6;
            string StandEasyPeriod;
            string LunchPeriod;
            string CorrectivePeriod;
            string AfternoonActivitiesGamePeriod;
            string SelfStudyPeriod;

            List<int> bnaQueryWeekId = new List<int>();
            ArrayList bnaQueryDateResult = new ArrayList();

            IQueryable<BnaClassRoutine> bnaClassRoutiness = _BnaClassRoutineRepository.Where(x => true);

            foreach (var item in bnaClassRoutiness)
            {
                if (item.WeekID == request.selectedCourseWeekId)
                {
                    bnaQueryDateResult.Add(item.Date);
                }
            }
            List<DateTime> dateList = bnaQueryDateResult.Cast<DateTime>().ToList();

            List<DateTime> filteredAndSortedDates = dateList.OrderBy(date => date).ToList();


            foreach (var item in bnaClassRoutiness)
            {
                foreach (var date in filteredAndSortedDates)
                {
                    if (item.Date == date)
                    {
                        string[] subjectCurriculumIdsString = item.BnaSubjectCurriculumId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        int[] subjectCurriculumIds = subjectCurriculumIdsString.Select(int.Parse).ToArray();

                        string[] selectedSubjectCurriculumIdsString = request.bnaSelectedSubjectCurriculumId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        int[] selectedSubjectCurriculumIds = selectedSubjectCurriculumIdsString.Select(int.Parse).ToArray();

                        foreach (var subjectCurriculumId in subjectCurriculumIds)
                        {
                            foreach (var selectedSubjectCurriculumId in selectedSubjectCurriculumIds)
                            {
                                if (subjectCurriculumId == selectedSubjectCurriculumId)
                                {
                                    string[] courseTitleIdsString = item.CourseTitleId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    int[] courseTitleIds = courseTitleIdsString.Select(int.Parse).ToArray();

                                    string[] selectedcourseTitleIdsString = request.selectedCourseTitleId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    int[] selectedcourseTitleIds = selectedcourseTitleIdsString.Select(int.Parse).ToArray();

                                    foreach (var courseTitleId in courseTitleIds)
                                    {
                                        foreach (var selectedcourseTitleId in selectedcourseTitleIds)
                                        {
                                            if (courseTitleId == selectedcourseTitleId)
                                            {
                                                string[] semesterIdsString = item.BnaSemesterId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                                int[] semesterIds = semesterIdsString.Select(int.Parse).ToArray();

                                                string[] selectedsemesterIdsString = request.selectedBnaSemesterId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                                int[] selectedsemesterIds = selectedsemesterIdsString.Select(int.Parse).ToArray();

                                                foreach (var semesterId in semesterIds)
                                                {
                                                    foreach (var selectedsemesterId in selectedsemesterIds)
                                                    {
                                                        if (semesterId == selectedsemesterId)
                                                        {
                                                            string[] courseSectionIdsString = item.CourseSectionId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                                            int[] courseSectionIds = courseSectionIdsString.Select(int.Parse).ToArray();

                                                            string[] selectedcourseSectionIdsString = request.selectedCourseSectionId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                                            int[] selectedcourseSectionIds = selectedcourseSectionIdsString.Select(int.Parse).ToArray();

                                                            foreach (var courseSectionId in courseSectionIds)
                                                            {
                                                                foreach (var selectedcourseSectionId in selectedcourseSectionIds)
                                                                {
                                                                    if (courseSectionId == selectedcourseSectionId)
                                                                    {
                                                                        string[] classPeriodIdsString = item.ClassPeriodId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                                                        int[] classPeriodIds = classPeriodIdsString.Select(int.Parse).ToArray();

                                                                        foreach (var classPeriodId in classPeriodIds)
                                                                        {
                                                                            var subjectName = _BnaSubjectNameRepository.Where(x=>x.BnaSubjectNameId == item.BnaSubjectNameId).Select(x=>x.SubjectName).FirstOrDefault();
                                                                            var instructorName = _TraineeBioDataGeneralInfoRepository.Where(x => x.TraineeId == item.TraineeId).Select(x => x.Name).FirstOrDefault();
                                                                            if (classPeriodId == 1)
                                                                            {
                                                                                period_1 = subjectName + "-" + instructorName;
                                                                            }
                                                                            if (classPeriodId == 2)
                                                                            {
                                                                                period_2 = subjectName + "-" + instructorName;
                                                                            }
                                                                            if (classPeriodId == 3)
                                                                            {
                                                                                period_3 = subjectName + "-" + instructorName;
                                                                            }
                                                                            if (classPeriodId == 4)
                                                                            {
                                                                                period_4 = subjectName + "-" + instructorName;
                                                                            }
                                                                            if (classPeriodId == 5)
                                                                            {
                                                                                period_5 = subjectName + "-" + instructorName;
                                                                            }
                                                                            if (classPeriodId == 6)
                                                                            {
                                                                                period_6 = subjectName + "-" + instructorName;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }




            List<BnaRoutineModel> selectModels = bnaClassRoutiness.Select(x => new BnaRoutineModel
            {
                Date = x.Date,
                WeekName = request.selectedCourseWeekId,
                SemesterName = x.BnaSemesterId
            }).ToList();
            return selectModels;

            //List<int> bnaSemesterWeekClassRoutineIds = new List<int>();

            //ArrayList bnaQueryBnaClassResult = new ArrayList();


            //IQueryable<BnaClassRoutine> bnaClassRoutines = _BnaClassRoutineRepository.Where(x => true);

            //foreach (var item in bnaClassRoutines)
            //{
            //    string[] semesterIdsString = item.BnaSemesterId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //    int[] bnaSemesterIds = semesterIdsString.Select(int.Parse).ToArray();
            //    foreach (var semesterId in bnaSemesterIds)
            //    {
            //        if (semesterId == request.BnaSemesterId)
            //        {
            //            if (item.WeekID == request.WeekID)
            //            {
            //                bnaSemesterWeekClassRoutineIds.Add(item.BnaClassRoutineId);
            //                bnaQueryBnaClassResult.Add(item);
            //            }
            //        }
            //    }
            //}


            //return bnaQueryBnaClassResult;
        }

    }

}
