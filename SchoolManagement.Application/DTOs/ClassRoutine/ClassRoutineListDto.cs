using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.InterServiceMark.converter;

namespace SchoolManagement.Application.DTOs.ClassRoutine
{
    public class ClassRoutineListDto : IClassRoutineDto
    {
        public int ClassRoutineId { get; set; }
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
        public int? BranchId { get; set; }
        public int? SubjectMarkId { get; set; }
        public int? MarkTypeId { get; set; }
        public int? TraineeId { get; set; }
        public string? CourseSectionId { get; set; }
        public string? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? CourseWeekId { get; set; }
        public int? AttendanceComplete { get; set; }
        public int? ResultSubmissionStatus { get; set; }
        public int? FinalApproveStatus { get; set; }
        public string? ClassLocation { get; set; }
        public string? TimeDuration { get; set; }
        public string? Remarks { get; set; }
        public string? ClassRoomName { get; set; }
        public string? ClassTopic { get; set; }


        public DateTime? Date { get; set; }
        public int? ClassTypeId { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


        public string? BaseSchoolName { get; set; }
        public string? BnaSubjectName { get; set; }
        public string? ClassPeriod { get; set; }
        public string? ClassPeriodDurationForm { get; set; }
        public string? ClassPeriodDurationTo { get; set; }
        public string? ClassType { get; set; }
        public string? CourseDuration { get; set; }
        public string? CourseModule { get; set; }
        public string? CourseName { get; set; }
        public string? CourseWeek { get; set; }
        public string? MarkType { get; set; }
        public string? Branch { get; set; }
        public string? CourseSection { get; set; }
        public string? Trainee { get; set; }
        public List<PerodListForm> perodListForm { get; set; }

    }

    public class PerodListForm
    {
        public int? subjectId { get; set; }
        public int? bnaSubjectNameId { get; set; }
        public int? traineeId { get; set; }
        public int? subjectMarkId { get; set; }
        public int? markTypeId { get; set; }
        public int? classCountPeriod { get; set; }
        public int? subjectCountPeriod { get; set; }
      
        public string? classPeriodId { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? PeriodFrom { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? PeriodTo { get; set; }
        public int? classTypeId { get; set; }
        public string? classRoomName { get; set; }
        public string? classTopic { get; set; }
    }
}
