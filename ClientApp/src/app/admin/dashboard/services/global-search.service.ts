import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

enum SearchType {
  Trainee,
  Instructor,
  Course,
  Search
}


@Injectable({
  providedIn: 'root'
})

export class GlobalSearchService {
  baseUrl: string;
  cachedData: {[key: string]: any};
  cacheDuration: number;
  constructor(private http: HttpClient) {
    this.cachedData = {};
    this.baseUrl = environment.apiUrl;
    this.cacheDuration = 60;
  }


  searchData(keywords:string, pageSize:number, pageIndex:number): Observable<any> {
    let params = new HttpParams();
    params = params.set('keyword',keywords);
    params = params.set('PageSize',pageSize);
    params = params.set('PageIndex',pageIndex);

    if(this.HaveCachedData(keywords,SearchType.Search,pageSize,pageIndex)) {
      let data = this.getCachedData(keywords,SearchType.Search,pageSize, pageIndex);
      return of (data["payload"]);
    }
    

    return this.http.get<any>(this.baseUrl+"/globalSearch/searchAll",{params:params}).pipe(
      map(response => {
        let data = {creationDate: (new Date()).getTime(),payload:response}
        this.setCachedData(keywords,data,SearchType.Search,pageSize,pageIndex);
        return response;
      })
    );
  }

  getInstructorDetail(instructorId:number): any {
    if(this.HaveCachedData(instructorId.toString(),SearchType.Instructor)) {
      return of (this.getCachedData(instructorId.toString(),SearchType.Instructor)["payload"]);
    }

    this.http.get<any>(this.baseUrl+`/globalSearch/get-searchedInstructorDetail/${instructorId}`).pipe(
      map(response=> {
        let data = {
          creationDate: (new Date()).getTime(),
          payload: response
        };

        this.setCachedData(instructorId.toString(),data,SearchType.Instructor)
        return response;
      })
    );
  }

  getTraineeDetail(traineeId: number): Observable<any> {
    if(this.HaveCachedData(traineeId.toString(),SearchType.Trainee)) {
      return of (this.getCachedData(traineeId.toString(),SearchType.Trainee)["payload"]);
    }

    return this.http.get<any>(this.baseUrl+`/globalSearch/get-searchedTraineeDetail/${traineeId}`).pipe(
      map(response => {
        let data = {creationDate: (new Date()).getDate(),payload:response}
        this.setCachedData(traineeId.toString(),data,SearchType.Trainee);
        return response;
      })
    );
  }

  getCourseDetail(courseDurationId): Observable<any> {
    if(this.HaveCachedData(courseDurationId.toString(),SearchType.Course)) {
      return of (this.getCachedData(courseDurationId.toString(),SearchType.Course)['payload']);
    }

    return this.http.get<any>(this.baseUrl+`/globalSearch/get-searchedCourseDetail/${courseDurationId}`).pipe(
      map(response => {
        let data = {creationDate: (new Date()).getDate(), payload: response}
        this.setCachedData(courseDurationId.toString(),data,SearchType.Course);
        return response;
      })
    )
  }


  HaveCachedData(key:string,searchType:SearchType,pageSize?:number,pageIndex?:number) {
     let uniqueIdentifier = this.setUniqueIdentifier(key,searchType,pageSize,pageIndex);

     let value = sessionStorage.getItem(uniqueIdentifier);

     if(value) {
      let curTime = (new Date).getTime();
      if(value["creationDate"]+this.cacheDuration*1000>curTime) {
        this.removeCachedData(uniqueIdentifier,searchType);
        return false;
      }

      return true;
     }

     return false;
  }


  getCachedData(uniqueIdentifier:string, searchType: SearchType,pageSize?:number,pageIndex?:number) {

    uniqueIdentifier = this.setUniqueIdentifier(uniqueIdentifier, searchType,pageSize,pageIndex);
    return JSON.parse(sessionStorage.getItem(uniqueIdentifier));
  }

  setCachedData(uniqueIdentifier:string, val:any, searchType: SearchType,pageSize?:number,pageIndex?:number) {
   uniqueIdentifier = this.setUniqueIdentifier(uniqueIdentifier, searchType,pageSize,pageIndex);
   console.log(uniqueIdentifier);
   sessionStorage.setItem(uniqueIdentifier, JSON.stringify(val));
  }

  setUniqueIdentifier(val:string, searchType: SearchType, pageSize?:number, pageIndex?:number):string {
    var uniqueIdentifier = "";
    if(searchType == SearchType.Trainee) {
      uniqueIdentifier= val+"trainee";
    } else if(searchType == SearchType.Instructor) {
      uniqueIdentifier=val + "instructor"
    } else if(searchType == SearchType.Course) {
      uniqueIdentifier= uniqueIdentifier+"course";
    } else if(searchType == SearchType.Search) {
      uniqueIdentifier= uniqueIdentifier+`${val}_search_${pageSize}_pageSize_${pageIndex}_pageIndex`;
    }

    return uniqueIdentifier;
  }

  removeCachedData(uniqueIdentifier:string, searchType: SearchType,pageSize?:number,pageIndex?:number) {
    uniqueIdentifier = this.setUniqueIdentifier(uniqueIdentifier,searchType,pageSize,pageIndex);

    sessionStorage.removeItem(uniqueIdentifier);
  }
}
