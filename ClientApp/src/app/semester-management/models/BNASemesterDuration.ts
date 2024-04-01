export interface BNASemesterDuration {
      bnaSemesterDurationId: number;
      bnaSubjectCurriculamId:number;
      courseDurationId:number;
      bnaSemesterId: number,
      departmentId : string,
      bnaSemesterName:string,
      bnaBatchId:number,
      startDate: Date,
      endDate: Date,
      semesterLocationType: number,
     //codeValueId:number,
      rankId: number,
      location:string, 
      isSemesterComplete: boolean,
      nextSemesterId: number,
      isApproved: boolean,
      approvedBy: string,
      approvedDate: Date,
      status:number,
      menuPosition:number,
      isActive: boolean
}
