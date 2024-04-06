import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { IAttendancePagination,AttendancePagination } from '../models/attendancePagination';
import { Attendance } from '../models/attendance';
import { SelectedModel } from '../../core/models/selectedModel';
import { map } from 'rxjs';
import { PostResponse } from 'src/app/core/models/PostResponse';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {
  baseUrl = environment.apiUrl;
  Attendances: Attendance[] = [];
  AttendancePagination = new AttendancePagination(); 
  constructor(private http: HttpClient) { }
 
  getAttendanceListForUpdate(pageNumber, pageSize,searchText,baseSchoolNameId,courseNameId,classPeriodId){
    let params = new HttpParams(); 
    
    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('baseSchoolNameId', baseSchoolNameId.toString());
    params = params.append('courseNameId', courseNameId.toString());
    params = params.append('classPeriodId', classPeriodId.toString());
    
    // attendance/get-attendancesForUpdate?PageSize=5&PageNumber=1&baseSchoolNameId=20&courseNameId=1065&classPeriodId=28
    return this.http.get<IAttendancePagination>(this.baseUrl + '/attendance/get-attendancesForUpdate', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Attendances = [...this.Attendances, ...response.body.items];
        this.AttendancePagination = response.body;
        return this.AttendancePagination;
      })
    ); 
  }
  
  getSelectedClassPeriodForAttendanceInstructorBySpRequest(traineeId){
    return this.http.get<any[]>(this.baseUrl + '/class-period/get-selectedClassPeriodForAttendanceInstructorSpRequest?traineeId='+traineeId);
  }
  getSelectedCourseDurationByParameterRequestFromClassRoutine(baseSchoolNameId,courseNameId,classPeriodId){
    return this.http.get<number>(this.baseUrl + '/course-duration/get-selectedCourseDurationByParameterRequestFromRoutine?baseSchoolNameId='+baseSchoolNameId+'&courseNameId='+courseNameId+'&classPeriodId='+classPeriodId);
  }
  getSelectedClassPeriodByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId,courseNameId,courseDurationId,date){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/class-period/get-selectedClassPeriodByParameterRequest?baseSchoolNameId='+baseSchoolNameId+'&courseNameId='+courseNameId+'&courseDurationId='+courseDurationId+'&date='+date);
  }
  getSelectedClassPeriodByBaseSchoolNameIdAndCourseNameIdforAttendances(baseSchoolNameId,courseNameId,courseDurationId,date){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/class-period/get-selectedClassPeriodByParameterRequestForAttendances?baseSchoolNameId='+baseSchoolNameId+'&courseNameId='+courseNameId+'&courseDurationId='+courseDurationId+'&date='+date);
  }
  // getSelectedClassPeriodByBaseSchoolNameIdAndCourseNameIdAndDate(baseSchoolNameId,courseNameId,date){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/class-period/get-selectedClassPeriodByParameterRequest?baseSchoolNameId='+baseSchoolNameId+'&courseNameId='+courseNameId);
  //class-period/get-selectedClassPeriodByParameterRequestForAttendances?baseSchoolNameId=20&courseNameId=1065&date=2%2F12%2F2022
//  }
  getCourseByBaseSchoolNameId(baseSchoolNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/course-name/get-selectedCourseByBaseNameId?baseSchoolNameId='+baseSchoolNameId)
  }

  getselectedclassroutine(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/class-routine/get-selectedClassRoutines')
  }

  getselectedbaseschools(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchools')
  }

  getselectedcoursename(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/course-name/get-selectedCourseNames')
  }

  getselectedbnasubjectname(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/bna-subject-name/get-selectedBnaSubjectNames')
  }
  getselectedclassperiod(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/class-period/get-selectedClassPeriod')
  }

  getselectedbnaattendanceremark(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/bna-attendance-remark/get-selectedBnaAttendanceRemarks')
  }
 

  getAttendances(pageNumber, pageSize,searchText) {

    let params = new HttpParams(); 
    
    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
   
    return this.http.get<IAttendancePagination>(this.baseUrl + '/attendance/get-attendances', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Attendances = [...this.Attendances, ...response.body.items];
        this.AttendancePagination = response.body;
        return this.AttendancePagination;
      })
    ); 
  }
  
  updateAttendanceList(model: any){
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    return this.http.post<PostResponse>(this.baseUrl + '/attendance/approved-attendancelist', model, httpOptions).pipe(
      map((attendanceUpdate: PostResponse) => {
        if (attendanceUpdate) {
          return attendanceUpdate;
        }
      })
    );
  }

  find(id: number) {
    return this.http.get<Attendance>(this.baseUrl + '/attendance/get-attendanceDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/attendance/update-attendance/'+id, model);
  }
  submit(model: any) {
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    
    return this.http.post<PostResponse>(this.baseUrl + '/attendance/save-attendancelist', model,httpOptions).pipe(
      map((Attendance: PostResponse) => {
        if (Attendance) {
          return Attendance;
        }
      })
    );
  } 
  submitAttendance(model: any) {
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    
    return this.http.post<PostResponse>(this.baseUrl + '/attendance/save-attendancelistnstructor', model,httpOptions).pipe(
      map((Attendance: PostResponse) => {
        if (Attendance) {
          return Attendance;
        }
      })
    );
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/attendance/delete-attendance/'+id);
  }



  //BNA Attendance Service


  getSelectedSubjectCurriculum(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/bna-subject-curriculum/get-selectedBnaSubjectCurriculums')
  } 

  getselectedcourseTitle(baseSchoolNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/course-duration/get-selectedCourseDurationBySchoolName?baseSchoolNameId='+baseSchoolNameId)
  }

  getSelectedBnaSemester(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/bna-semester/get-selectedBnaSemesters')
  }

  getDropdownCourseSection(baseSchoolNameId){
    return this.http.get<any[]>(this.baseUrl + '/course-section/get-dorpdown-courseSection?baseSchoolNameId='+baseSchoolNameId)
  } 

  getDropdownClassPeriod(baseSchoolNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/bnaClass-period/get-bnaClassPeriod?&baseSchoolNameId='+baseSchoolNameId)
  } 

  getAttendanceTraineeList(baseSchoolNameId, selectedbnaSubjectCurriculam, selectedcourseTitle, selectedbnaSemester, selectedcourseSection, selectedclassPeriod, selectedDate){
    return this.http.get<any[]>(this.baseUrl + '/bnaClass-attendance/get-BnaClassAttendance?&baseSchoolNameId='+baseSchoolNameId+'&bnaSubjectCurriculamId='+selectedbnaSubjectCurriculam+'&courseTitleId='+selectedcourseTitle+'&semesterId='+selectedbnaSemester+'&courseSectionId='+selectedcourseSection+'&classPeriodId='+selectedclassPeriod+'&date='+selectedDate)
  }

}
