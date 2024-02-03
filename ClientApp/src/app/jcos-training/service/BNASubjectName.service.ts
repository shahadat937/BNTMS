import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'; 
import { environment } from 'src/environments/environment';
import {IBNASubjectNamePagination, BNASubjectNamePagination } from '../models/BNASubjectNamePagination'
import { BNASubjectName } from '../models/BNASubjectName';
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
@Injectable({
  providedIn: 'root'
})
export class BNASubjectNameService {
  baseUrl = environment.apiUrl;
  BNASubjectNames: BNASubjectName[] = [];
  status:number;
  BNASubjectNamePagination = new BNASubjectNamePagination();
  constructor(private http: HttpClient) { }

  getSubjectNameByFromCourseNameIdAndBranchId(courseNameId,branchId){
    return this.http.get<BNASubjectName[]>(this.baseUrl + '/bna-subject-name/get-selectedSubjectNameByFromCourseNameIdAndBranchId?courseNameId='+courseNameId+'&branchId='+branchId);
  }

  getSelectedSubjectNameByCourseNameId(courseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/bna-subject-name/get-selectedSubjectNameByCourseNameId?courseNameId='+courseNameId);
  }
  // getSelectedBnaSemester(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/bna-semester/get-selectedBnaSemesters')
  // }
  // getSelectedCourseModuleByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId:number,courseNameId:number){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/course-module/get-selectedCourseModulesByBaseSchoolNameIdAndCourseNameId?baseSchoolNameId='+baseSchoolNameId+'&courseNameId='+courseNameId)
  // }
  // getSelectedCourseByParameters(baseSchoolNameId:number,courseNameId:number, courseModuleId:number, status:number){
  //   return this.http.get<BNASubjectName[]>(this.baseUrl + '/bna-subject-name/get-celectedCourseByParameters?baseSchoolNameId='+baseSchoolNameId+'&courseNameId='+courseNameId+'&courseModuleId='+courseModuleId+'&status='+status)
  // }
  // getSelectedsubjectsBySchoolAndCourse(baseSchoolNameId:number,courseNameId:number){
  //   return this.http.get<BNASubjectName[]>(this.baseUrl + '/bna-subject-name/get-selectedSubjectBySchoolAndCourse?baseSchoolNameId='+baseSchoolNameId+'&courseNameId='+courseNameId)
  // }
  // getSelectedSubjectCategory(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/subject-category/get-selectedSubjectCategories')
  // }
 
  // getSelectedSubjectCurriculum(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/bna-subject-curriculum/get-selectedBnaSubjectCurriculums')
  // } 
  // getSelectedSubjectClassification(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/subject-classification/get-selectedSubjectClassification')
  // }

  getSelectedSchoolName(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchools')
  }

  getSelectedCourseName(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/course-name/get-selectedCourseByCourseTypeId')
  }
  getselectedSubjectNameByBranchId(saylorBranchId,courseNameId){
    return this.http.get<BNASubjectName[]>(this.baseUrl + '/bna-subject-name/get-bnaSubjectNameListByBranchIdForJCOs?saylorBranchId='+saylorBranchId+'&courseNameId='+courseNameId)
  }
  getselectedSubjectNameList(courseDurationId){
    return this.http.get<any[]>(this.baseUrl + '/bna-subject-name/get-bnaSubjectNameListForJCOsByCourseNameId?courseDurationId='+courseDurationId)
  }
  getselectedSubjectName(){
    return this.http.get<BNASubjectName[]>(this.baseUrl + '/bna-subject-name/get-bnaSubjectNameListByCourseNameInQExamId')
  }
  getSelectedSubjectType(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/subject-type/get-getSelectedSubjectType')
  }
  
  getSelectedResultStatus(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/result-status/get-selectedResultStatuses')
  }
  getSelectedBranch(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/branch/get-selectedBranchForJCOs')
  }
  getselectedSaylorBranch(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/saylor-branch/get-selectedSaylorBranchs')
  }
  getselectedSaylorSubBranch(saylorBranchId:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/saylor-sub-branch/get-selectedSubBranchBySaylorBranchId?saylorBranchId='+saylorBranchId)
  }
  getBNASubjectNames(pageNumber, pageSize,searchText,status) {

    let params = new HttpParams();
    
    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('status', status.toString());

    return this.http.get<IBNASubjectNamePagination>(this.baseUrl + '/bna-subject-name/get-bnaSubjectNames', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BNASubjectNames = [...this.BNASubjectNames, ...response.body.items];
        this.BNASubjectNamePagination = response.body;
        return this.BNASubjectNamePagination;
      })
    );
  }

  find(id: number) {
    return this.http.get<BNASubjectName>(this.baseUrl + '/bna-subject-name/get-bnaSubjectNameDetail/' + id);
  }
  update(id: number,model: any) { 
    return this.http.put(this.baseUrl + '/bna-subject-name/update-bnaSubjectName/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/bna-subject-name/save-bnaSubjectName', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/bna-subject-name/delete-bnaSubjectName/'+id);
  }
}
