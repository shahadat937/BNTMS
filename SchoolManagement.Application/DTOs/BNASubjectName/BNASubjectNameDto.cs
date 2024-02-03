using System;
namespace SchoolManagement.Application.DTOs.BnaSubjectName
{
    public class BnaSubjectNameDto : IBnaSubjectNameDto
    {
        public int BnaSubjectNameId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? SubjectCategoryId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? CourseNameId { get; set; }
        public string? CourseName { get; set; }
        public int? CourseTypeId { get; set; }
        public int? BranchId { get; set; }
        public int? SaylorBranchId { get; set; }
        public int? SaylorSubBranchId { get; set; }
        public int? ResultStatusId { get; set; }
        public int? SubjectTypeId { get; set; }
        public int? KindOfSubjectId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? SubjectClassificationId { get; set; }
        public string? SubjectName { get; set; }
        public string? SubjectNameBangla { get; set; }
        public string? SubjectShortName { get; set; }
        public string? SubjectCode { get; set; }
        public string? TotalMark { get; set; }
        public string? PassMarkBna { get; set; }
        public string? PassMarkBup { get; set; }
        public string? ClassTestMark { get; set; }
        public string? AssignmentMark { get; set; }
        public string? CaseStudyMark { get; set; }
        public string? TotalPeriod { get; set; }
        public string? QExamTime { get; set; }
        public string? Remarks { get; set; }
        public int? SubjectGreading { get; set; }
        public int? Status { get; set; }
        public string? PaperNo { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public int? SubjectActiveStatus { get; set; }
        public double? ContactHour { get; set; }
        public double? CreditHour { get; set; }

        public string? SubjectCategoryName { get; set; }
        public string? BnaSubjectCurriculum { get; set; }
        public string? SubjectType { get; set; }
        public string? CourseModule { get; set; }
        public string? KindOfSubject { get; set; }
        public string? SubjectClassification { get; set; } 
        public string? ResultStatus { get; set; }
        public string? Branch { get; set; }
        public string? SaylorBranch { get; set; }

    }
}

