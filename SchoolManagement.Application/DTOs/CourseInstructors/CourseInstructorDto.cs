using System;

namespace SchoolManagement.Application.DTOs.CourseInstructors
{
    public class CourseInstructorDto : ICourseInstructorDto 
    {

        public int CourseInstructorId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? DepartmentId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? TraineeId { get; set; }
        public int? SubjectMarkId { get; set; }
        public int? MarkTypeId { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }
        public int? ExamMarkEntry { get; set; } 


        public string? CourseDuration { get; set; }
        public string? BaseSchoolName { get; set; }
        public string? BnaSubjectName { get; set; }
        public string? CourseName { get; set; }
        public string? CourseModule { get; set; }
        public string? BNASemester { get; set; }
        public string? Trainee { get; set; }
        public string? MarkType { get; set; }
        public string? TraineeName { get; set; }
        public string? TraineePno { get; set; }
        public string? TraineeRank { get; set; }
        public string? SaylorRank { get; set; }
        public int? TraineeStatusId { get; set; }
    }
}
