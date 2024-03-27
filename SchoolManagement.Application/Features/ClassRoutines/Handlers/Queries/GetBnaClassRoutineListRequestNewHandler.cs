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
        private readonly ISchoolManagementRepository<Domain.CourseWeekAll> _CourseWeekAllRepository;
        private readonly ISchoolManagementRepository<CourseSection> _CourseSectionRepository;
        private readonly ISchoolManagementRepository<BnaClassPeriod> _BnaClassPeriodRepository;
        
        public GetBnaClassRoutineListRequestNewHandler(ISchoolManagementRepository<BnaClassRoutine> BnaClassRoutineRepository, ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, ISchoolManagementRepository<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository, ISchoolManagementRepository<Domain.CourseWeekAll> CourseWeekAllRepository, ISchoolManagementRepository<CourseSection> CourseSectionRepository, ISchoolManagementRepository<BnaClassPeriod> BnaClassPeriodRepository)
        {
            _BnaClassRoutineRepository = BnaClassRoutineRepository;
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
            _CourseWeekAllRepository = CourseWeekAllRepository;
            _CourseSectionRepository = CourseSectionRepository;
            _BnaClassPeriodRepository = BnaClassPeriodRepository;
        }

        public async Task<List<BnaRoutineModel>> Handle(GetBnaClassRoutineListRequestNew request, CancellationToken cancellationToken)
        {
            string weekName;
            

            List<int> bnaQueryWeekId = new List<int>();
            ArrayList bnaQueryDateResult = new ArrayList();

            List<BnaRoutineModel> selectModels = new List<BnaRoutineModel>();

            List<BnaRoutineModel> selectMergeModels = new List<BnaRoutineModel>();

            IQueryable<BnaClassRoutine> bnaClassRoutiness = _BnaClassRoutineRepository.Where(x => true);

            foreach (var item in bnaClassRoutiness)
            {
                if (item.WeekID == request.selectedCourseWeekId)
                {
                    bnaQueryDateResult.Add(item.Date);
                }
            }

            HashSet<DateTime> uniqueDatesSet = new HashSet<DateTime>(bnaQueryDateResult.Cast<DateTime>());

            ArrayList uniqueDatesArrayList = new ArrayList();
            foreach (DateTime date in uniqueDatesSet)
            {
                uniqueDatesArrayList.Add(date);
            }

            weekName = _CourseWeekAllRepository.Where(x => x.WeekID == request.selectedCourseWeekId).Select(x => x.WeekName).FirstOrDefault();

            List<DateTime> dateList = uniqueDatesArrayList.Cast<DateTime>().ToList();

            List<DateTime> filteredAndSortedDates = dateList.OrderBy(date => date).ToList();



            string[] selectedcourseSectionIdsString = request.selectedCourseSectionId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] selectedcourseSectionIds = selectedcourseSectionIdsString.Select(int.Parse).ToArray();

            foreach (var item in bnaClassRoutiness)
            {
                foreach (var date in filteredAndSortedDates)
                {
                    if (item.Date == date)
                    {
                        string courseSectionName = null;
                        string ExtraCurriculamPeriod = null;
                        string period_1 = null;
                        string period_2 = null;
                        string period_3 = null;
                        string period_4 = null;
                        string period_5 = null;
                        string period_6 = null;
                        string StandEasyPeriod = null;
                        string LunchPeriod = null;
                        string CorrectivePeriod = null;
                        string AfternoonActivitiesGamePeriod = null;
                        string SelfStudyPeriod = null;

                        string[] courseSectionIdsString = item.CourseSectionId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        int[] courseSectionIds = courseSectionIdsString.Select(int.Parse).ToArray();


                        foreach (var courseSectionId in courseSectionIds)
                        {
                            foreach (var selectedcourseSectionId in selectedcourseSectionIds)
                            {
                                if (courseSectionId == selectedcourseSectionId)
                                {
                                    string[] courseTitleIdsString = item.CourseTitleId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    int[] courseTitleIds = courseTitleIdsString.Select(int.Parse).ToArray();

                                    string[] selectedcourseTitleIdsString = request.selectedCourseTitleId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    int[] selectedcourseTitleIds = selectedcourseTitleIdsString.Select(int.Parse).ToArray();

                                    courseSectionName = _CourseSectionRepository.Where(x => x.CourseSectionId == courseSectionId).Select(x => x.SectionName).FirstOrDefault();

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
                                                                        string[] classPeriodIdsString = item.ClassPeriodId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                                                        int[] classPeriodIds = classPeriodIdsString.Select(int.Parse).ToArray();

                                                                        foreach (var classPeriodId in classPeriodIds)
                                                                        {
                                                                            var subjectName = _BnaSubjectNameRepository.Where(x=>x.BnaSubjectNameId == item.BnaSubjectNameId).Select(x=>x.SubjectName).FirstOrDefault();
                                                                            var instructorName = _TraineeBioDataGeneralInfoRepository.Where(x => x.TraineeId == item.TraineeId).Select(x => x.Name).FirstOrDefault();
                                                                            var periodName = _BnaClassPeriodRepository.Where(x => x.BnaClassPeriodId == classPeriodId).Select(x => x.BnaClassPeriodName).FirstOrDefault();
                                                                            if (classPeriodId == 1)
                                                                            {
                                                                                period_1 = subjectName + "-" + instructorName + " (T=" + item.PeriodFrom.ToString(@"hh\:mm")+"-"+ item.PeriodTo.ToString(@"hh\:mm") + ") " + "(R-" + item.ClassRoomName +")";
                                                                            }
                                                                            else if (classPeriodId == 2)
                                                                            {
                                                                                period_2 = subjectName + "-" + instructorName + " (T=" + item.PeriodFrom.ToString(@"hh\:mm") + "-" + item.PeriodTo.ToString(@"hh\:mm") + ") " + "(R-" + item.ClassRoomName + ")";
                                                                            }
                                                                            else if (classPeriodId == 3)
                                                                            {
                                                                                period_3 = subjectName + "-" + instructorName + " (T=" + item.PeriodFrom.ToString(@"hh\:mm") + "-" + item.PeriodTo.ToString(@"hh\:mm") + ") " + "(R-" + item.ClassRoomName + ")";
                                                                            }
                                                                            else if (classPeriodId == 4)
                                                                            {
                                                                                period_4 = subjectName + "-" + instructorName + " (T=" + item.PeriodFrom.ToString(@"hh\:mm") + "-" + item.PeriodTo.ToString(@"hh\:mm") + ") " + "(R-" + item.ClassRoomName + ")";
                                                                            }
                                                                            else if (classPeriodId == 5)
                                                                            {
                                                                                period_5 = subjectName + "-" + instructorName + " (T=" + item.PeriodFrom.ToString(@"hh\:mm") + "-" + item.PeriodTo.ToString(@"hh\:mm") + ") " + "(R-" + item.ClassRoomName + ")";
                                                                            }
                                                                            else if (classPeriodId == 6)
                                                                            {
                                                                                period_6 = subjectName + "-" + instructorName + " (T=" + item.PeriodFrom.ToString(@"hh\:mm") + "-" + item.PeriodTo.ToString(@"hh\:mm") + ") " + "(R-" + item.ClassRoomName + ")";
                                                                            }
                                                                            else if (classPeriodId == 7)
                                                                            {
                                                                                ExtraCurriculamPeriod = periodName + " (T=" + item.PeriodFrom.ToString(@"hh\:mm") + "-" + item.PeriodTo.ToString(@"hh\:mm") + ") ";
                                                                            }
                                                                            else if (classPeriodId == 8)
                                                                            {
                                                                                StandEasyPeriod = periodName + " (T=" + item.PeriodFrom.ToString(@"hh\:mm") + "-" + item.PeriodTo.ToString(@"hh\:mm") + ") ";
                                                                            }
                                                                            else if (classPeriodId == 9)
                                                                            {
                                                                                LunchPeriod = periodName + " (T=" + item.PeriodFrom.ToString(@"hh\:mm") + "-" + item.PeriodTo.ToString(@"hh\:mm") + ") ";
                                                                            }
                                                                            else if (classPeriodId == 10)
                                                                            {
                                                                                CorrectivePeriod = periodName + " (T=" + item.PeriodFrom.ToString(@"hh\:mm") + "-" + item.PeriodTo.ToString(@"hh\:mm") + ") ";
                                                                            }
                                                                            else if (classPeriodId == 6)
                                                                            {
                                                                                AfternoonActivitiesGamePeriod = periodName + " (T=" + item.PeriodFrom.ToString(@"hh\:mm") + "-" + item.PeriodTo.ToString(@"hh\:mm") + ") ";
                                                                            }
                                                                            else if (classPeriodId == 6)
                                                                            {
                                                                                SelfStudyPeriod = periodName + " (T=" + item.PeriodFrom.ToString(@"hh\:mm") + "-" + item.PeriodTo.ToString(@"hh\:mm") + ") ";
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

                                    BnaRoutineModel routineModel = new BnaRoutineModel
                                    {
                                        Date = date,
                                        WeekName = weekName,
                                        CourseSectionName = courseSectionName,
                                        CourseSectionId = selectedcourseSectionId,
                                        Period1 = period_1,
                                        Period2 = period_2,
                                        Period3 = period_3,
                                        Period4 = period_4,
                                        Period5 = period_5,
                                        Period6 = period_6,
                                        ExtraCurriculamPeriod = ExtraCurriculamPeriod,
                                        StandEasyPeriod = StandEasyPeriod,
                                        LunchPeriod = LunchPeriod,
                                        CorrectivePeriod = CorrectivePeriod,
                                        AfternoonActivitiesGamePeriod = AfternoonActivitiesGamePeriod,
                                        SelfStudyPeriod = SelfStudyPeriod
                                    };
                                    selectModels.Add(routineModel);
                                }
                            }
                        }
                        
                    }
                }
            }


            foreach (var dates in filteredAndSortedDates)
            {
                foreach (var selectedcourseSectionId in selectedcourseSectionIds)
                {
                    string mergeWeekName = null;
                    string mergecourseSectionName = null;
                    string mergeExtraCurriculamPeriod = null;
                    string mergeperiod_1 = null;
                    string mergeperiod_2 = null;
                    string mergeperiod_3 = null;
                    string mergeperiod_4 = null;
                    string mergeperiod_5 = null;
                    string mergeperiod_6 = null;
                    string mergeStandEasyPeriod = null;
                    string mergeLunchPeriod = null;
                    string mergeCorrectivePeriod = null;
                    string mergeAfternoonActivitiesGamePeriod = null;
                    string mergeSelfStudyPeriod = null;
                    foreach (var item in selectModels)
                    {
                        if (dates.ToString() == item.Date.ToString())
                        {
                            if (selectedcourseSectionId.ToString() == item.CourseSectionId.ToString())
                            {
                                if (item.CourseSectionName != null)
                                {
                                    mergecourseSectionName = item.CourseSectionName.ToString();
                                }
                                if (item.ExtraCurriculamPeriod != null)
                                {
                                    mergeExtraCurriculamPeriod = item.ExtraCurriculamPeriod.ToString();
                                }
                                if (item.Period1 != null)
                                {
                                    mergeperiod_1 = item.Period1.ToString();
                                }
                                if (item.Period2 != null)
                                {
                                    mergeperiod_2 = item.Period2.ToString();
                                }
                                if (item.Period3 != null)
                                {
                                    mergeperiod_3 = item.Period3.ToString();
                                }
                                if (item.Period4 != null)
                                {
                                    mergeperiod_4 = item.Period4.ToString();
                                }
                                if (item.Period5 != null)
                                {
                                    mergeperiod_5 = item.Period5.ToString();
                                }
                                if (item.Period6 != null)
                                {
                                    mergeperiod_6 = item.Period6.ToString();
                                }
                                if (item.StandEasyPeriod != null)
                                {
                                    mergeStandEasyPeriod = item.StandEasyPeriod.ToString();
                                }
                                if (item.LunchPeriod != null)
                                {
                                    mergeLunchPeriod = item.LunchPeriod.ToString();
                                }
                                if (item.CorrectivePeriod != null)
                                {
                                    mergeCorrectivePeriod = item.CorrectivePeriod.ToString();
                                }
                                if (item.AfternoonActivitiesGamePeriod != null)
                                {
                                    mergeAfternoonActivitiesGamePeriod = item.AfternoonActivitiesGamePeriod.ToString();
                                }
                                if (item.SelfStudyPeriod != null)
                                {
                                    mergeSelfStudyPeriod = item.SelfStudyPeriod.ToString();
                                }
                                mergeWeekName = item.WeekName.ToString();
                            }
                        }
                    }
                    BnaRoutineModel mergeRoutineModel = new BnaRoutineModel
                    {
                        WeekName = mergeWeekName,
                        Date = dates,
                        CourseSectionName = mergecourseSectionName,
                        ExtraCurriculamPeriod = mergeExtraCurriculamPeriod,
                        Period1 = mergeperiod_1,
                        Period2 = mergeperiod_2,
                        Period3 = mergeperiod_3,
                        Period4 = mergeperiod_4,
                        Period5 = mergeperiod_5,
                        Period6 = mergeperiod_6,
                        StandEasyPeriod = mergeStandEasyPeriod,
                        LunchPeriod = mergeLunchPeriod,
                        CorrectivePeriod = mergeCorrectivePeriod,
                        AfternoonActivitiesGamePeriod = mergeAfternoonActivitiesGamePeriod,
                        SelfStudyPeriod = mergeSelfStudyPeriod
                    };
                    selectMergeModels.Add(mergeRoutineModel);
                }
            }


            //List<BnaRoutineModel> selectModels = bnaClassRoutiness.Select(x => new BnaRoutineModel
            //{
            //    Date = x.Date,
            //    WeekName = request.selectedCourseWeekId,
            //    SemesterName = x.BnaSemesterId
            //}).ToList();
            return selectMergeModels;
            //return selectModels;

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
