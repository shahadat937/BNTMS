using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaSubjectName
    {
        public BnaSubjectName()
        {
            Attendances = new HashSet<Attendance>();
            BnaClassSchedules = new HashSet<BnaClassSchedule>();
            BnaClassTests = new HashSet<BnaClassTest>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
            BnaExamInstructorAssigns = new HashSet<BnaExamInstructorAssign>();
            BnaExamMarks = new HashSet<BnaExamMark>();
            BnaExamRoutineLogs = new HashSet<BnaExamRoutineLog>();
            BnaExamSchedules = new HashSet<BnaExamSchedule>();
            ClassRoutines = new HashSet<ClassRoutine>();
            CourseInstructors = new HashSet<CourseInstructor>();
            CourseNomenees = new HashSet<CourseNomenee>();

            CourseTasks = new HashSet<CourseTask>();
            GuestSpeakerQuationGroups = new HashSet<GuestSpeakerQuationGroup>();
            InstructorAssignments = new HashSet<InstructorAssignment>();
            RoutineNotes = new HashSet<RoutineNote>();
            SubjectMarks = new HashSet<SubjectMark>();
            TdecQuationGroups = new HashSet<TdecQuationGroup>();
            TraineeAssignmentSubmits = new HashSet<TraineeAssignmentSubmit>();
            TrainingObjectives = new HashSet<TrainingObjective>();
            TrainingSyllabi = new HashSet<TrainingSyllabus>();
        }

        public int BnaSubjectNameId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? SubjectCategoryId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? BranchId { get; set; }
        public int? SaylorSubBranchId { get; set; }
        public int? SaylorBranchId { get; set; }
        public int? ResultStatusId { get; set; }
        public int? SubjectTypeId { get; set; }
        public int? KindOfSubjectId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? SubjectClassificationId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectShortName { get; set; }
        public string SubjectNameBangla { get; set; }
        public string SubjectCode { get; set; }
        public string TotalMark { get; set; }
        public string PassMarkBna { get; set; }
        public string PassMarkBup { get; set; }
        public string ClassTestMark { get; set; }
        public string AssignmentMark { get; set; }
        public string CaseStudyMark { get; set; }
        public string TotalPeriod { get; set; }
        public string QexamTime { get; set; }
        public string Remarks { get; set; }
        public int? SubjectGreading { get; set; }
        public int? Status { get; set; }
        public string PaperNo { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int? SubjectActiveStatus { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BnaSemester BnaSemester { get; set; }
        public virtual BnaSubjectCurriculum BnaSubjectCurriculum { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual CourseModule CourseModule { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual CourseType CourseType { get; set; }
        public virtual KindOfSubject KindOfSubject { get; set; }
        public virtual CodeValue ResultStatus { get; set; }
        public virtual SaylorBranch SaylorBranch { get; set; }
        public virtual SaylorSubBranch SaylorSubBranch { get; set; }
        public virtual SubjectCategory SubjectCategory { get; set; }
        public virtual SubjectClassification SubjectClassification { get; set; }
        public virtual SubjectType SubjectType { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<BnaClassSchedule> BnaClassSchedules { get; set; }
        public virtual ICollection<BnaClassTest> BnaClassTests { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<BnaExamInstructorAssign> BnaExamInstructorAssigns { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<BnaExamRoutineLog> BnaExamRoutineLogs { get; set; }
        public virtual ICollection<BnaExamSchedule> BnaExamSchedules { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }

        public virtual ICollection<CourseNomenee> CourseNomenees { get; set; }

        public virtual ICollection<CourseTask> CourseTasks { get; set; }
        public virtual ICollection<GuestSpeakerQuationGroup> GuestSpeakerQuationGroups { get; set; }
        public virtual ICollection<InstructorAssignment> InstructorAssignments { get; set; }
        public virtual ICollection<RoutineNote> RoutineNotes { get; set; }
        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<TdecQuationGroup> TdecQuationGroups { get; set; }
        public virtual ICollection<TraineeAssignmentSubmit> TraineeAssignmentSubmits { get; set; }
        public virtual ICollection<TrainingObjective> TrainingObjectives { get; set; }
        public virtual ICollection<TrainingSyllabus> TrainingSyllabi { get; set; }
    }
}
