export interface ExamResult {
    universityCourseResultId: number;
    courseDurationId?: number;
    traineeId: number;
    courseNomineeId?: number;
    traineeNominationId?: number;
    courseTermId?: number;
    courseLevelId?: number;
    baseSchoolNameId?: number;
    totalCredit?: number;
    totalMark?: number;
    gpa?: number;
    achievedTotalCredit?: number;
    achievedTotalMark?: number;
    achievedGPA?: number;
    remark?: string;
    status?: number;
    menuPosition?: number;
    isActive: boolean;
}
