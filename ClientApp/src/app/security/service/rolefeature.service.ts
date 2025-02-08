import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'; 
import { environment } from '../../../../src/environments/environment';
import {IRoleFeaturePagination, RoleFeaturePagination } from '../models/RoleFeaturePagination'
import { map } from 'rxjs';
import { SelectedModel } from '../../core/models/selectedModel';
import { RoleFeature } from '../models/rolefeature';
import { IFeaturePagination } from '../models/featurePagination';
import { Feature } from '../models/feature';
@Injectable({
  providedIn: 'root'
})
export class RoleFeatureService {
  baseUrl = environment.securityUrl;
  RoleFeatures: RoleFeature[] = [];
  Features: any[] = [];
  FeaturePagination : any;
  RoleFeaturePagination = new RoleFeaturePagination();
  constructor(private http: HttpClient) { }

  getRoleFeatures(pageNumber, pageSize,searchText) {

    let params = new HttpParams();
    
    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
   

    return this.http.get<IRoleFeaturePagination>(this.baseUrl + '/RoleFeature/get-RoleFeatures', { observe: 'response', params })
    .pipe(
      map(response => {
        this.RoleFeatures = [...this.RoleFeatures, ...response.body.items];
        this.RoleFeaturePagination = response.body;
        return this.RoleFeaturePagination;
      })
    );
   
  }

  getFeaturesbyModule(moduleId: number){
    return this.http.get<Feature>(this.baseUrl+ '/Feature/get-features-by-module-id/'+moduleId)
    .pipe(response => {
      return response;
    })
  }
  

  find(Roleid:string,Featureid:number) {

    const result = this.http.get<RoleFeature>(this.baseUrl + '/RoleFeature/get-RoleFeatureDetail?RoleId='+Roleid+'&FeatureId='+Featureid);
    return result;
  }
   

  update(Roleid:string,Featureid:number,model: any) { 
    console.log('output', Roleid, Featureid, model)
    //return this.http.put(this.baseUrl + '/RoleFeature/update-RoleFeature/'+id, model);
    return this.http.put(this.baseUrl + '/RoleFeature/update-RoleFeature?RoleId='+Roleid+'&FeatureId='+Featureid, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/RoleFeature/save-RoleFeature', model);
  } 
  delete(Roleid:number,Featureid){
    //return this.http.delete(this.baseUrl + '/RoleFeature/delete-RoleFeature/'+id);
    return this.http.delete(this.baseUrl + '/RoleFeature/delete-RoleFeature?RoleId='+Roleid+'&FeatureId='+Featureid);
    
  }

  getselectedrole(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/Role/get-selectedroles') 
  }

  getselectedfeature(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/Feature/get-selectedfeatures') 
  }

  getFeatures(pageNumber, pageSize,searchText) {

    let params = new HttpParams();
    
    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
   

    return this.http.get<IFeaturePagination>(this.baseUrl + '/feature/get-features', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Features = [...this.Features, ...response.body.items];
        this.FeaturePagination = response.body;
        return this.FeaturePagination;
      })
    );
   
  }

  getselectedmodule(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/module/get-selectedModules') 
  }
  
}
