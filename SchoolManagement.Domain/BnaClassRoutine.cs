using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain
{
    public class BnaClassRoutine : BaseDomainEntity
    {
        //public ClassRoutine()
        //{
        //    Attendances = new HashSet<Attendance>();
        //    BnaExamAttendances = new HashSet<BnaExamAttendance>();
        //    BnaExamInstructorAssigns = new HashSet<BnaExamInstructorAssign>();
        //    BnaExamMarks = new HashSet<BnaExamMark>();
        //    RoutineNotes = new HashSet<RoutineNote>();
        //}

        public int BnaClassRoutineId { get; set; }
        public string? BnaSubjectCurriculumId { get; set; }
        public string? DepartmentId { get; set; }
        public int? CourseModuleId { get; set; }

        public string? BnaSemesterId { get; set; }
        public string? ClassPeriodId { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? PeriodFrom { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? PeriodTo { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? ClassCountPeriod { get; set; }
        public int? SubjectCountPeriod { get; set; }
        public string? CourseNameId { get; set; }
        public int? WeekID { get; set; }
        public int? SubjectMarkId { get; set; }
        public int? MarkTypeId { get; set; }
        public int? TraineeId { get; set; }
        public string? CourseSectionId { get; set; }
        public string? CourseDurationId { get; set; }
        public int? BranchId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? AttendanceComplete { get; set; }
        public int? ExamMarkComplete { get; set; }
        public string? ClassLocation { get; set; }
        public string? TimeDuration { get; set; }
        public string? ClassRoomName { get; set; }
        public string? ClassTopic { get; set; }
        public string? Remarks { get; set; }
        public DateTime? Date { get; set; }
        public int? ClassTypeId { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? ResultSubmissionStatus { get; set; }
        public int? FinalApproveStatus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        //public virtual BaseSchoolName? BaseSchoolName { get; set; }
        //public virtual BnaSubjectName? BnaSubjectName { get; set; }
        //public virtual Branch? Branch { get; set; }
        //public virtual ClassPeriod? ClassPeriod { get; set; }
        //public virtual ClassType? ClassType { get; set; }
        //public virtual CourseDuration? CourseDuration { get; set; }
        //public virtual CourseName? CourseName { get; set; }
        //public virtual CourseModule? CourseModule { get; set; }
        //public virtual CourseWeek? CourseWeek { get; set; }
        //public virtual MarkType? MarkType { get; set; }
        //public virtual CourseSection? CourseSection { get; set; }
        //public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        //public virtual ICollection<Attendance> Attendances { get; set; }
        //public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        //public virtual ICollection<BnaExamInstructorAssign> BnaExamInstructorAssigns { get; set; }
        //public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        //public virtual ICollection<RoutineNote> RoutineNotes { get; set; }
    }
}
