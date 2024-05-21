import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment'; 
import { ExamResult } from '../models/exam-result';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';

@Injectable({
  providedIn: 'root'
})
export class ExamResultService {
  baseUrl = environment.apiUrl;
  ExamResults: ExamResult[] = []; 
  constructor(private http: HttpClient) { }


 
   

 

  GetCourseDuration(id: number) {
    console.log('service '+ id);
    return this.http.get<SelectedModel[]>(this.baseUrl + '/course-duration/get-selectedCourseDurationBySchoolName/?baseSchoolNameId='+id);
  }


  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/UniversityCourseResult/update-UniversityCourseResult/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/UniversityCourseResult/save-universityCourseResult', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/UniversityCourseResult/delete-UniversityCourseResult/'+id);
  }

}
