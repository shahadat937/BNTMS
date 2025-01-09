import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { IUserPagination,UserPagination } from '../models/UserPagination';
import { User } from '../models/User';
import { Observable, map, shareReplay } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
import { BIODataGeneralInfoPagination, IBIODataGeneralInfoPagination } from 'src/app/trainee-biodata/models/BIODataGeneralInfoPagination';
import { BIODataGeneralInfo } from 'src/app/trainee-biodata/models/BIODataGeneralInfo';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private cache = new Map<string, Observable<any[]>>();
  baseUrl = environment.securityUrl;
  dropDownUrl = environment.apiUrl;
  Users: User[] = [];
  UserPagination = new UserPagination();
  BIODataGeneralInfos: BIODataGeneralInfo[] = [];
  BIODataGeneralInfoPagination = new BIODataGeneralInfoPagination();
  constructor(private http: HttpClient) { }

  getUsers(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http.get<IUserPagination>(this.baseUrl + '/users/get-users', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Users = [...this.Users, ...response.body.items];
        this.UserPagination = response.body;
        return this.UserPagination;
      })
    );
   
  }

  
  // getTraineeList(pno) {

  //   return this.http.get<any[]>(this.dropDownUrl + '/trainee-bio-data-general-info/get-traineeListForUserCreate?pno='+pno)
  //   .pipe(
  //     map(response => {
        
  //       return response;
  //     })
  //   ); 
   
  // }
  getTraineeList(pno: string, pageSize: number, pageNumber: number): Observable<any[]> {
   

    const request$ = this.http.get<any[]>(`${this.dropDownUrl}/trainee-bio-data-general-info/get-traineeListForUserCreate?pno=${pno}&pageSize=${pageSize}&pageNumber=${pageNumber}`)
      .pipe(
        map(response => response),
        shareReplay(1)
      );


    return request$;
  }


  getInstructors(pageNumber, pageSize,searchText) {

    let params = new HttpParams();
    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http.get<IUserPagination>(this.baseUrl + '/Users/get-teacher-users', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Users = [...this.Users, ...response.body.items];
        this.UserPagination = response.body;
        return this.UserPagination;
      })
    );
   
  }

  getTrainees(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http.get<IUserPagination>(this.baseUrl + '/Users/get-student-users', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Users = [...this.Users, ...response.body.items];
        this.UserPagination = response.body;
        return this.UserPagination;
      })
    );
   
  }


  getselectedbranchinfo(){
    return this.http.get<SelectedModel[]>(this.dropDownUrl + '/branch-info/get-selectedBranchInfos')
  }


  getSelectedTraineeByPno(pno){
    return this.http.get<SelectedModel[]>(this.dropDownUrl + '/trainee-bio-data-general-info/get-autocompleteTraineeByPnoForUser?pno='+pno)
      .pipe(
        map((response:[]) => response.map(item => item))
      )
  }

  getAllTrainee(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http.get<IUserPagination>(this.baseUrl + '/Users/get-traineeList', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Users = [...this.Users, ...response.body.items];
        this.UserPagination = response.body;
        return this.UserPagination;
      })
    );
   
  }
  getAllInstructor(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http.get<IUserPagination>(this.baseUrl + '/Users/get-instructorList', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Users = [...this.Users, ...response.body.items];
        this.UserPagination = response.body;
        return this.UserPagination;
      })
    );
   
  }


  find(id: string) {
    return this.http.get<User>(this.baseUrl + '/users/get-userDetail/' + id);
  }
  findUserByTraineeId(id: string) {
    return this.http.get<User>(this.baseUrl + '/users/get-userDetailByTraineeId/' + id);
  }

  update(id:any, model: any) {
    return this.http.put(this.baseUrl + '/users/update-user?userId='+id, model);
  }
  updateUserAsServiceInstructor(id:any, model: any, branchId) {
    return this.http.put(this.baseUrl + '/users/update-user-as-service-instructor?userId='+id+"&branchId="+branchId, model);
  }
  releseServiceInstructor(id:any) {
    return this.http.put(this.baseUrl + '/users/relese-service-instructor?userId='+id, null);
  }
  
  resetPassword(id:any, model: any) {
    return this.http.post(this.baseUrl + '/Users/reset-userPassword?userId='+id, model);
  } 
  submit(model: any) {
    return this.http.post(this.baseUrl + '/users/save-user', model);
  } 

  saveUserList(model: any) {
    return this.http.post(this.baseUrl + '/Users/save-userlist', model);
  }  

  delete(id:number){
    return this.http.delete(this.baseUrl + '/users/delete-user/'+id);
  }
}
