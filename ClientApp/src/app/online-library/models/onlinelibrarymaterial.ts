export interface OnlineLibraryMaterial {
      onlineLibraryId: number; 
      documentName: string,
      baseSchoolNameId: number,
      aurhorName: string;
      baseSchoolName : string,
      documentTypeId: number,
      documentTypeName : string,
      documentLink:string,
      publisherName : string,
      showRightId:number,
      downloadRightId:number,
      isApproved:boolean,
      approvedDate:Date,
      approvedUser:string,
      status:number,
      menuPosition:number,
      isActive: boolean
}
