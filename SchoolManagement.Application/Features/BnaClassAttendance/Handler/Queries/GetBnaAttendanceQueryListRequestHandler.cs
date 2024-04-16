using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaClassAttendance.Request.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassAttendance.Handler.Queries
{
    public class GetBnaAttendanceQueryListRequestHandler : IRequestHandler<GetBnaAttendanceQueryListRequest, List<BnaAttendanceModel>>
    {
        private readonly ISchoolManagementRepository<CourseNomenee> _CourseNomeneeRepository;
        private readonly ISchoolManagementRepository<BnaClassRoutine> _BnaClassRoutineRepository;
        private readonly ISchoolManagementRepository<TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;
        private readonly ISchoolManagementRepository<Domain.BnaClassAttendance> _BnaClassAttendanceRepository;

        public GetBnaAttendanceQueryListRequestHandler(ISchoolManagementRepository<CourseNomenee> CourseNomeneeRepository, ISchoolManagementRepository<BnaClassRoutine> BnaClassRoutineRepository, ISchoolManagementRepository<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository, ISchoolManagementRepository<BnaSubjectName> bnaSubjectNameRepository, ISchoolManagementRepository<Domain.BnaClassAttendance> bnaClassAttendanceRepository)
        {
            _CourseNomeneeRepository = CourseNomeneeRepository;
            _BnaClassRoutineRepository = BnaClassRoutineRepository;
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
            _BnaSubjectNameRepository = bnaSubjectNameRepository;
            _BnaClassAttendanceRepository = bnaClassAttendanceRepository;
        }

        public async Task<List<BnaAttendanceModel>> Handle(GetBnaAttendanceQueryListRequest request, CancellationToken cancellationToken)
        {

            List<BnaAttendanceModel> selectModels = new List<BnaAttendanceModel>();

            DateTime date = DateTime.ParseExact(request.Date, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            //DateTime dateFormate = DateTime.ParseExact(request.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            IQueryable<BnaClassRoutine> bnaClassRoutines = _BnaClassRoutineRepository.Where(x => x.Date == date);

            

            IQueryable<Domain.BnaClassAttendance> bnaClassAttendances = _BnaClassAttendanceRepository.Where(x => x.AttendanceDate == date && x.BnaSubjectCurriculumId == request.BnaSubjectCurriculamId && x.CourseTitleId == request.CourseTitleId && x.BnaSemesterId == request.SemesterId && x.CourseSectionId == request.CourseSectionId && x.ClassPeriodId == request.ClassPeriodId);

            if (bnaClassAttendances.Any())
            {
                foreach (var item in bnaClassAttendances)
                {
                    var traineeName = _TraineeBioDataGeneralInfoRepository.Where(x => x.TraineeId == item.TraineeId).Select(x => x.Name).FirstOrDefault();

                    BnaAttendanceModel attendanceModel = new BnaAttendanceModel
                    {
                        TraineeId = item.TraineeId,
                        TraineeName = traineeName,
                        SubjectId = item.SubjectId,
                        InstructorId = item.InstructorId,
                        Attendance = item.AttendanceStatus,
                        Remark = item.Remark,
                        UpdateStatus = true
                    };
                    selectModels.Add(attendanceModel);
                }
            }
            else
            {
                foreach (var item in bnaClassRoutines)
                {
                    string[] subjectCurriculumIdsString = item.BnaSubjectCurriculumId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int[] subjectCurriculumIds = subjectCurriculumIdsString.Select(int.Parse).ToArray();

                    string[] courseTitleIdsString = item.CourseTitleId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int[] courseTitleIds = courseTitleIdsString.Select(int.Parse).ToArray();

                    string[] bnaSemesterIdsString = item.BnaSemesterId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int[] bnaSemesterIds = bnaSemesterIdsString.Select(int.Parse).ToArray();

                    string[] courseSectionIdsString = item.CourseSectionId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int[] courseSectionIds = courseSectionIdsString.Select(int.Parse).ToArray();

                    string[] classPeriodIdsString = item.ClassPeriodId.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int[] classPeriodIds = classPeriodIdsString.Select(int.Parse).ToArray();

                    foreach (var subjectCurriculumId in subjectCurriculumIds)
                    {
                        if (subjectCurriculumId == request.BnaSubjectCurriculamId)
                        {
                            foreach (var courseTitleId in courseTitleIds)
                            {
                                if (courseTitleId == request.CourseTitleId)
                                {
                                    foreach (var bnaSemesterId in bnaSemesterIds)
                                    {
                                        if (bnaSemesterId == request.SemesterId)
                                        {
                                            foreach (var courseSectionId in courseSectionIds)
                                            {
                                                if (courseSectionId == request.CourseSectionId)
                                                {
                                                    foreach (var classPeriodId in classPeriodIds)
                                                    {
                                                        if (classPeriodId == request.ClassPeriodId)
                                                        {
                                                            IQueryable<CourseNomenee> courseNomenees = _CourseNomeneeRepository.Where(x => x.BnaSubjectNameId == item.BnaSubjectNameId && x.BnaSubjectCurriculumId == subjectCurriculumId && x.BnaSemesterId == bnaSemesterId && x.CourseSectionId == courseSectionId);
                                                            foreach (var courseNomenee in courseNomenees)
                                                            {
                                                                var traineeName = _TraineeBioDataGeneralInfoRepository.Where(x => x.TraineeId == courseNomenee.TraineeId).Select(x => x.Name).FirstOrDefault();
                                                                var subjectName = _BnaSubjectNameRepository.Where(x => x.BnaSubjectNameId == item.BnaSubjectNameId).Select(x => x.SubjectName).FirstOrDefault();
                                                                var instructorName = _TraineeBioDataGeneralInfoRepository.Where(x => x.TraineeId == item.TraineeId).Select(x => x.Name).FirstOrDefault();

                                                                BnaAttendanceModel attendanceModel = new BnaAttendanceModel
                                                                {
                                                                    TraineeId = courseNomenee.TraineeId,
                                                                    TraineeName = traineeName,
                                                                    SubjectId = item.BnaSubjectNameId,
                                                                    SubjectName = subjectName,
                                                                    InstructorId = item.TraineeId,
                                                                    InstructorName = instructorName
                                                                };
                                                                selectModels.Add(attendanceModel);
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

            return selectModels;
        }
        
    }
}
