import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CourseTermPagination,ICourseTermination } from '../models/coursetermPagination';
import { CourseTerm } from '../models/course-term';
import { map } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';

@Injectable({
  providedIn: 'root'
})
export class CourseTermService {
  baseUrl = environment.apiUrl;
  CourseTerms: CourseTerm[] = [];
  CourseTermPagination = new CourseTermPagination();
  constructor(private http: HttpClient) { }

  getCourseTerms(pageNumber, pageSize, searchText) { 

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    
    return this.http.get<ICourseTermination>(this.baseUrl + '/CourseTerm/get-courseTerms', { observe: 'response', params })
    .pipe(
      map(response => {
        this.CourseTerms = [...this.CourseTerms, ...response.body.items];
        this.CourseTermPagination = response.body;
        return this.CourseTermPagination;
      })
    );
   
  }

  getselectedCourseTerm(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/CourseTerm/get-selectedcourseTerms')
  }
   
   

  find(id: number) {
    return this.http.get<CourseTerm>(this.baseUrl + '/CourseTerm/get-courseTermDetail/' + id);
  }
   

  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/CourseTerm/update-courseTerm/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/CourseTerm/save-courseTerm', model);
  } 
  delete(id:number){
    return this.http.delete(this.baseUrl + '/CourseTerm/delete-courseTerm/'+id);
  }

}
