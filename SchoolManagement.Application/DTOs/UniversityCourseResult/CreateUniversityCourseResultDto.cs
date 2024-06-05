using SchoolManagement.Application.DTOs.IndividualNotices;
using SchoolManagement.Application.DTOs.UniversityCourseResult;
using System;

namespace SchoolManagement.Application.DTOs.UniversityCourseResult
{
    public class CreateUniversityCourseResultDto : IUniversityCourseResultDto
    {


        public int UniversityCourseResultId { get; set; }

        public int? CourseDurationId { get; set; }

        public int TraineeId { get; set; }

        public int? CourseNomeneeId { get; set; }

        public int? TraineeNominationId { get; set; }

        public int? CourseTermId { get; set; }

        public int? CourseLevelId { get; set; }

        public int? BaseSchoolNameId { get; set; }
        public double? TotalCredit { get; set; }
        public double? TotalMark { get; set; }
        public double? GPA { get; set; }
        public double? AchievedTotalCredit { get; set; }
        public double? AchievedTotalMark { get; set; }
        public double? AchievedGPA { get; set; }

        public string Remark { get; set; }

     
  
        public int? Status { get; set; }

        public int? MenuPosition { get; set; }

        public bool IsActive { get; set; }

        public List<UniversityCourseResultDto>? TraineeListForm { get; set; }
    }
}
