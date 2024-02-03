using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.BnaExamMark.converter;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ForeignCourseOtherDoc.converter;

namespace SchoolManagement.Application.DTOs.ForeignCourseOtherDoc
{ 
    public class ForeignCourseOtherDocListDto
    {
        public int ForeignCourseOtherDocId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? FinancialSanctionId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public bool? Ticket { get; set; }
        public bool? Visa { get; set; }
        public bool? Passport { get; set; }
        public bool? CovidTest { get; set; }
        public bool? MedicalTest { get; set; }
        public List<TraineeListForeignFormDto> traineeListForm { get; set; }
        public bool IsActive { get; set; }

        //public int ForeignCourseOtherDocId { get; set; }
        //public int? CourseDurationId { get; set; }
        //public int? CourseNameId { get; set; }
        //public int? TraineeNominationId { get; set; }
        //public int? TraineeId { get; set; }
        //public bool? Ticket { get; set; }
        //public bool? Visa { get; set; }
        //public bool? Passport { get; set; }
        //public bool? CovidTest { get; set; }
        //public bool? MedicalTest { get; set; }
        //public string? Remark { get; set; }
        //public int? Status { get; set; }
        //public int? MenuPosition { get; set; }
        //public bool IsActive { get; set; }

        //public List<TraineeListForeignFormDto>? traineeListForm { get; set; }

    }
}
