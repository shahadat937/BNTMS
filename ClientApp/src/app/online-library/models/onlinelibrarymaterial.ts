export interface OnlineLibraryMaterial {
      onlineLibraryId: number; 
      documentName: string,
      baseSchoolNameId: number,
      baseSchoolName : string,
      documentTypeId: number,
      documentLink:string,
      showRightId:number,
      downloadRightId:number,
      isApproved:boolean,
      approvedDate:Date,
      approvedUser:string,
      status:number,
      menuPosition:number,
      isActive: boolean
}
