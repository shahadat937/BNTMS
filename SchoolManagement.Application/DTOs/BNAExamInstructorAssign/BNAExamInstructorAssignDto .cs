using System;

namespace SchoolManagement.Application.DTOs.BnaExamInstructorAssign
{
    public class BnaExamInstructorAssignDto : IBnaExamInstructorAssignDto
    {
        public int BnaExamInstructorAssignId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? ClassRoutineId { get; set; }
        public int? BnaInstructorTypeId { get; set; }
        public int? TraineeId { get; set; }
        public string? ExamLocation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }


        public string? BaseSchoolName { get; set; }
        public string? BnaInstructorType { get; set; }
        public string? BnaSubjectName { get; set; }
        public string? ClassRoutine { get; set; }
        public string? CourseDuration { get; set; }
        public string? CourseModule { get; set; }
        public string? CourseName { get; set; }
        public string? Trainee { get; set; }
        public string? TraineePno { get; set; }
        public string? TraineeRank { get; set; }

    }
}
