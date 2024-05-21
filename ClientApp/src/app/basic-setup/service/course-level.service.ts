import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CourseLevelPagination,ICourseLevelPagination } from '../models/courselevelPagination';
import { CourseLevel } from '../models/course-level';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';

@Injectable({
  providedIn: 'root'
})
export class CourseLevelService {
  baseUrl = environment.apiUrl;
  CourseLevels: CourseLevel[] = [];
  CourseLevelPagination = new CourseLevelPagination();
  constructor(private http: HttpClient) { }

  getCourseLevels(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<ICourseLevelPagination>(this.baseUrl + '/CourseLevel/get-courseLevels', { observe: 'response', params })
    .pipe(
      map(response => {
        this.CourseLevels = [...this.CourseLevels, ...response.body.items];
        this.CourseLevelPagination = response.body;
        return this.CourseLevelPagination;
      })
    );
   
  }

  getselectedCourseLevel(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/CourseLevel/get-selectedcourseLevels')
  }
   
   

  find(id: number) {
    return this.http.get<CourseLevel>(this.baseUrl + '/CourseLevel/get-courseLevelDetail/' + id);
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/CourseLevel/update-courseLevel/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/CourseLevel/save-courseLevel', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/CourseLevel/delete-courseLevel/'+id);
  }

}
