import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment'; 
import { ExamResult } from '../models/exam-result';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { PostResponse } from 'src/app/core/models/PostResponse';

@Injectable({
  providedIn: 'root'
})
export class ExamResultService {
  baseUrl = environment.apiUrl;
  ExamResults: ExamResult[] = []; 
  constructor(private http: HttpClient) { }


  GetCourseDuration(id: number) {
    return this.http.get<SelectedModel[]>(this.baseUrl + '/course-duration/get-selectedCourseDurationBySchoolName/?baseSchoolNameId='+id);
  }

  FindCourseResultDurationID(id: number,courseDurationId :number)
{ 
     return this.http.get<any>(this.baseUrl +'/UniversityCourseResult/get-GetUniversityCourseResultListBySchoolIdAndDurationId/?baseSchoolNameId='+id+'&courseDurationId='+courseDurationId)
}

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/UniversityCourseResult/update-UniversityCourseResult/'+id, model);
  }
  submit(model: any) {
    return this.http.post<PostResponse>(this.baseUrl + '/UniversityCourseResult/save-universityCourseResult', model).pipe(
      map((BnaClassTest: PostResponse) => {
        if (BnaClassTest) {
          return BnaClassTest;
        }
      })
    );
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/UniversityCourseResult/delete-UniversityCourseResult/'+id);
  }

}