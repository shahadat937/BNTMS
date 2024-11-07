import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { OnlineLibraryMaterial } from '../models/onlinelibrarymaterial';
import { HttpClient, HttpParams } from '@angular/common/http';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { IOnlineLibraryPagination,OnlineLibraryPagination  } from '../models/onlineLibraryPagination';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OnlinelibraryService {

  baseUrl = environment.apiUrl;
  OnlineLibraryMaterial : OnlineLibraryMaterial[] = [];
  OnlineLibraryMaterialPagination = new OnlineLibraryPagination();
  constructor(private http: HttpClient) { }

  getselectedDocumentType(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/document-type/get-selectedDocumentTypes')
  }

  getselectedShowRight(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/show-right/get-selectedShowRight')
  }

  getselecteddownloadright(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/download-right/get-selectedDownloadRights')
  }

  getOnlineLibraryMaterials(pageNumber, pageSize,searchText) {

    let params = new HttpParams(); 
    
    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    
   
    return this.http.get<IOnlineLibraryPagination>(this.baseUrl + '/online-library/get-OnlineLibrarysMeterials', { observe: 'response', params })
    .pipe(
      map(response => {
        this.OnlineLibraryMaterial = [...this.OnlineLibraryMaterial, ...response.body.items];
        this.OnlineLibraryMaterialPagination = response.body;
        return this.OnlineLibraryMaterialPagination;
      })
    ); 
  }

  getOnlineLibraryMaterialsByUser(pageNumber, pageSize, searchText, userId){
    let params = new HttpParams(); 
    
    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IOnlineLibraryPagination>(this.baseUrl + `/online-library/get-online-librarys-meterials-by-user/${userId}`, { observe: 'response', params })
    .pipe(
      map(response => {
        this.OnlineLibraryMaterial = [...this.OnlineLibraryMaterial, ...response.body.items];
        this.OnlineLibraryMaterialPagination = response.body;
        return this.OnlineLibraryMaterialPagination;
      })
    ); 
  }

  submit(model: any) {
    
    return this.http.post<any>(this.baseUrl + '/online-library/save-OnlineLibrary', model,{
      reportProgress: true,
      observe: 'events',
    }).pipe(
      map((OnlineLibraryMaterial: any) => {
        if (OnlineLibraryMaterial) {
          return OnlineLibraryMaterial;
        }
      })
    );
  }
 
}
