using SchoolManagement.Application.DTOs.BnaExamMark.converter;
using SchoolManagement.Application.DTOs.CourseNomenees.converter;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseNomenees
{
    public class CreateCourseNomeneeDto : ICourseNomeneeDto  
    {
        public int CourseNomeneeId { get; set; }
        public int? TraineeNominationId { get; set; }
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

       
        public List<CourseNomeneeListFormDto>? courseNomeneeForm { get; set; }

        

    }
}
