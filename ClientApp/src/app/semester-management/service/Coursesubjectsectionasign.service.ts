import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ITraineeNominationPagination,TraineeNominationPagination } from '../models/traineenominationPagination';
//import { TraineeNomination } from '../models/traineenomination';
import { SelectedModel } from '../../core/models/selectedModel';
import { map } from 'rxjs';
import { PostResponse } from 'src/app/core/models/PostResponse';
import { TraineeList} from '../../attendance-management/models/traineeList'
import { TraineeListForExamMark } from 'src/app/exam-management/models/traineeListforexammark';
import { TraineeListNewEntryEvaluation } from 'src/app/trainee-biodata/models/traineeList';
import { TraineeListForForeignCourseOtherDoc } from 'src/app/air-ticket/models/traineeListforforeigncourseotherdoc';
import { nomeneeSubjectSection } from '../models/nomeneeSubjectSection';

@Injectable({
  providedIn: 'root'
})
export class CoursesubjectsectionasignService {
  baseUrl = environment.apiUrl;
  NomeneeSubjectSections: nomeneeSubjectSection[] = [];

  constructor(private http: HttpClient) { }



  BnaNomeneeSubjectSectionAsignId(schollNameId,courseNameId,bnaSubjectCurriculumId,bnaSemesterId) {
    return this.http.get<[]>(this.baseUrl + '/course-Nomenee/get-BnaNomeneeSubjectSectionAsign?schollNameId='+schollNameId+'&courseNameId='+courseNameId+'&bnaSubjectCurriculumId='+bnaSubjectCurriculumId+'&bnaSemesterId='+bnaSemesterId);
  }


  
  BnaNomeneeSubjectSectionAlredyAsignId(traineeNominationId: any) {
    return this.http.get<[]>(this.baseUrl + '/course-Nomenee/get-BnaNomeneeSubjectSectionAlredyAsign?traineeNominationId='+traineeNominationId);
  }

  //return this.http.get<ClassRoutine[]>

  getselectedcoursedurationForBna(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/course-section/get-selectedCourseSectionForBna')
  }
 

  find(id  : any) {
    return  null;
  }

  getselectedbaseschools(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchools')
  }
  getselectedbaseschoolsByBase(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }

  getselectedcoursedurationbyschoolname(baseSchoolNameId:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/course-duration/get-selectedCourseDurationBySchoolName?baseSchoolNameId='+baseSchoolNameId)
  }

/*
  submit(model: any) {
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    return this.http.post<PostResponse>(this.baseUrl + '/course-Nomenee/save-CourseNomeneelist', model, httpOptions).pipe(
      map((TraineeNomination: PostResponse) => {
        if (TraineeNomination) {
          return TraineeNomination;
        }
      })
    );
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

 
  submit(model: any) {
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    return this.http.post<PostResponse>(this.baseUrl + '/course-Nomenee/save-CourseNomeneelist', model, httpOptions).pipe(
      map((TraineeNomination: PostResponse) => {
        if (TraineeNomination) {
          return TraineeNomination;
        }
      })
    );
  }
*/


submitList(model:any){
  return this.http.post<PostResponse>(this.baseUrl + '/course-Nomenee/save-CourseNomenee', model).pipe(
    map((nomeneeSubjectSection: PostResponse) => {
      if (nomeneeSubjectSection) {
        return nomeneeSubjectSection;
      } 
    })
  );
}

submit(model: any) {
  const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
   
  return this.http.post<PostResponse>(this.baseUrl + '/course-Nomenee/save-CourseNomenee', model,httpOptions).pipe(
    map((nomeneeSubjectSection: PostResponse) => {
 
      if (nomeneeSubjectSection) {
        
        return nomeneeSubjectSection;
      }
    })
  );
} 


update(model: any) {
  const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
   
  return this.http.put<PostResponse>(this.baseUrl + '/course-Nomenee/update-CourseNomenees', model,httpOptions).pipe(
    map((nomeneeSubjectSection: PostResponse) => {
 
      if (nomeneeSubjectSection) {
        
        return nomeneeSubjectSection;
      }
    })
  );
} 
 /*submit(model: any) {
  const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
  return this.http.post<PostResponse>(this.baseUrl + '/course-Nomenee/save-CourseNomenee', model,httpOptions).pipe(
    map((NomeneeSubjectSection: PostResponse) => {
      if (NomeneeSubjectSection) {
        return NomeneeSubjectSection;
      }
    })
  );
} 

 submit(model: any) {
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    return this.http.post<PostResponse>(this.baseUrl + '/course-Nomenee/save-CourseNomeneelist', model, httpOptions).pipe(
      map((NomeneeSubjectSection: PostResponse) => {
        if (NomeneeSubjectSection) {
          return NomeneeSubjectSection;
        }
      })
    );
  }*/

}