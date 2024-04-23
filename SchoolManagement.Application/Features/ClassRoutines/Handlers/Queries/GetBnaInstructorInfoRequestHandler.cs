using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetBnaInstructorInfoRequestHandler : IRequestHandler<GetBnaInstructorInfoRequest, List<BnaInstructorModel>>
    {
        private readonly ISchoolManagementRepository<BnaClassRoutine> _BnaClassRoutineRepository;
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;
        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;
        private readonly ISchoolManagementRepository<Domain.CourseWeekAll> _CourseWeekAllRepository;
        private readonly ISchoolManagementRepository<CourseSection> _CourseSectionRepository;
        private readonly ISchoolManagementRepository<Rank> _BnaRankRepository;

        public GetBnaInstructorInfoRequestHandler(ISchoolManagementRepository<BnaClassRoutine> BnaClassRoutineRepository, ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, ISchoolManagementRepository<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository, ISchoolManagementRepository<Domain.CourseWeekAll> CourseWeekAllRepository, ISchoolManagementRepository<CourseSection> CourseSectionRepository, ISchoolManagementRepository<Rank> BnaRankRepository)
        {
            _BnaClassRoutineRepository = BnaClassRoutineRepository;
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
            _CourseWeekAllRepository = CourseWeekAllRepository;
            _CourseSectionRepository = CourseSectionRepository;
            _BnaRankRepository = BnaRankRepository;
        }

        public async Task<List<BnaInstructorModel>> Handle(GetBnaInstructorInfoRequest request, CancellationToken cancellationToken)
        {
            List<int?> InstructorId = new List<int?>();

            List<int> bnaQueryWeekId = new List<int>();
            ArrayList bnaQueryDateResult = new ArrayList();

            List<BnaInstructorModel> selectModels = new List<BnaInstructorModel>();

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
                        string[] courseSectionIdsString = item.CourseSectionId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        int[] courseSectionIds = courseSectionIdsString.Select(int.Parse).ToArray();


                        foreach (var courseSectionId in courseSectionIds)
                        {
                            foreach (var selectedcourseSectionId in selectedcourseSectionIds)
                            {
                                if (courseSectionId == selectedcourseSectionId)
                                {
                                    string[] courseNameIdsString = item.CourseNameId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    int[] courseNameIds = courseNameIdsString.Select(int.Parse).ToArray();

                                    string[] selectedcourseNameIdsString = request.selectedCourseNameId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    int[] selectedcourseNameIds = selectedcourseNameIdsString.Select(int.Parse).ToArray();

                                    foreach (var courseNameId in courseNameIds)
                                    {
                                        foreach (var selectedcourseNameId in selectedcourseNameIds)
                                        {
                                            if (courseNameId == selectedcourseNameId)
                                            {
                                                string[] courseDurationIdsString = item.CourseDurationId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                                int[] courseDurationIds = courseDurationIdsString.Select(int.Parse).ToArray();

                                                string[] selectedcourseDurationIdsString = request.selectedCourseDurationId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                                int[] selectedcourseDurationIds = selectedcourseDurationIdsString.Select(int.Parse).ToArray();
                                                foreach (var courseDurationId in courseDurationIds)
                                                {
                                                    foreach (var selectedcourseDurationId in selectedcourseDurationIds)
                                                    {
                                                        if (courseDurationId == selectedcourseDurationId)
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
                                                                                        InstructorId.Add(item.TraineeId);
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

                }
            }

            var filteredList = InstructorId.Where(id => id.HasValue);

            List<int?> uniqueInstructorId = filteredList.Distinct().ToList();

            foreach (var item in uniqueInstructorId)
            {
                var instructorName = _TraineeBioDataGeneralInfoRepository.Where(x => x.TraineeId == item).Select(x => x.Name).FirstOrDefault();
                var rank = _TraineeBioDataGeneralInfoRepository.Where(x => x.TraineeId == item).Select(x => x.RankId).FirstOrDefault();
                var rankName = _BnaRankRepository.Where(x => x.RankId == rank).Select(x => x.Position).FirstOrDefault();
                var traineeCode = _TraineeBioDataGeneralInfoRepository.Where(x => x.TraineeId == item).Select(x => x.ShortCode).FirstOrDefault();
                BnaInstructorModel instructorModel = new BnaInstructorModel
                {
                    InstructorName = instructorName,
                    InstructorRank = rankName,
                    InstructorCode = traineeCode
                };
                selectModels.Add(instructorModel);
            }

            return selectModels;
        }


        }
}
