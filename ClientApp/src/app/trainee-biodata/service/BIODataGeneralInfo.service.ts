import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, catchError, throwError} from 'rxjs';
import { SelectedModel } from '../../../../src/app/core/models/selectedModel';
import { environment } from '../../../../src/environments/environment';
import { BIODataGeneralInfo } from '../models/BIODataGeneralInfo';
import {IBIODataGeneralInfoPagination, BIODataGeneralInfoPagination } from '../models/BIODataGeneralInfoPagination'

@Injectable({
  providedIn: 'root'
})
export class BIODataGeneralInfoService {

  baseUrl = environment.apiUrl;
  securityUrl = environment.securityUrl;
  BIODataGeneralInfos: BIODataGeneralInfo[] = [];
  BIODataGeneralInfoPagination = new BIODataGeneralInfoPagination();
  constructor(private http: HttpClient) { }
  
  postFile(fileToUpload:File){
    const endpoint= '/src/assets/img';
    const formData:FormData=new FormData();
    formData.append('bnaPhotoUrl', fileToUpload, fileToUpload.name);
    return this.http
    .post(endpoint,formData);
  }

  getTraineeListForUpdate(baseSchoolNameId,searchText){
    return this.http.get<BIODataGeneralInfo[]>(this.baseUrl + '/trainee-nomination/get-nominatedTraineeForProfileUpdatespRequest?baseSchoolNameId='+baseSchoolNameId+'&searchText='+searchText)
  }
  whiteSpaceRemove(value){
    return value.replace(/\s/g, '')
   }
  // getTraineeListForUpdate(pageNumber, pageSize,searchText) {

  //   let params = new HttpParams();

  //   params = params.append('searchText', searchText.toString());
  //   params = params.append('pageNumber', pageNumber.toString());
  //   params = params.append('pageSize', pageSize.toString());
  //   return this.http.get<IBIODataGeneralInfoPagination>(this.baseUrl + '/trainee-bio-data-general-info/get-traineeBioDataGeneralInfoes', { observe: 'response', params })
  //   .pipe(
  //     map(response => {
  //       this.BIODataGeneralInfos = [...this.BIODataGeneralInfos, ...response.body.items];
  //       this.BIODataGeneralInfoPagination = response.body;
  //       return this.BIODataGeneralInfoPagination;
  //     })
  //   );
  // }

  getBIODataGeneralInfos(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IBIODataGeneralInfoPagination>(this.baseUrl + '/trainee-bio-data-general-info/get-foreignOfficerBioDataGeneralInfoes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BIODataGeneralInfos = [...this.BIODataGeneralInfos, ...response.body.items];
        this.BIODataGeneralInfoPagination = response.body;
        return this.BIODataGeneralInfoPagination;
      })
    );
  }
  getBIODataGeneralInfosForMid(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IBIODataGeneralInfoPagination>(this.baseUrl + '/trainee-bio-data-general-info/get-midBioDataGeneralInfoes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BIODataGeneralInfos = [...this.BIODataGeneralInfos, ...response.body.items];
        this.BIODataGeneralInfoPagination = response.body;
        return this.BIODataGeneralInfoPagination;
      })
    );
  }
  getBIODataGeneralInfosForIs(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IBIODataGeneralInfoPagination>(this.baseUrl + '/trainee-bio-data-general-info/get-i-s-BioDataGeneralInfoes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BIODataGeneralInfos = [...this.BIODataGeneralInfos, ...response.body.items];
        this.BIODataGeneralInfoPagination = response.body;
        return this.BIODataGeneralInfoPagination;
      })
    );
  }

  getBIODataGeneralInfosForCivil(pageNumber, pageSize,searchText, traineeStatusId) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('traineeStatusId', traineeStatusId);
    return this.http.get<IBIODataGeneralInfoPagination>(this.baseUrl + '/trainee-bio-data-general-info/get-BioDataGeneralInfoes-by-trainee-status', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BIODataGeneralInfos = [...this.BIODataGeneralInfos, ...response.body.items];
        this.BIODataGeneralInfoPagination = response.body;
        return this.BIODataGeneralInfoPagination;
      })
    );
  }
  getServiceInstructorBioData(pageNumber, pageSize,searchText, branchId) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('branchId', branchId);
    return this.http.get<any>(this.baseUrl + '/trainee-bio-data-general-info/get-service-instructor-biodata', { observe: 'response', params })
    .pipe(
      map(response => {
       
        return response.body;
      })
    );
  }
  getBIODataGeneralInfosForCadet(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IBIODataGeneralInfoPagination>(this.baseUrl + '/trainee-bio-data-general-info/get-cadetBioDataGeneralInfoes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BIODataGeneralInfos = [...this.BIODataGeneralInfos, ...response.body.items];
        this.BIODataGeneralInfoPagination = response.body;
        return this.BIODataGeneralInfoPagination;
      })
    );
  }

  getCivilInstructorBIOData(pageNumber, pageSize,searchText) {

    let params = new HttpParams();
    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IBIODataGeneralInfoPagination>(this.baseUrl + '/trainee-bio-data-general-info/get-civilInstructorBioDataGeneralInfoes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BIODataGeneralInfos = [...this.BIODataGeneralInfos, ...response.body.items];
        this.BIODataGeneralInfoPagination = response.body;
        return this.BIODataGeneralInfoPagination;
      })
    );
  }
//autocomplete for FamilyInfo
getSelectedPno(pno){
  return this.http.get<SelectedModel[]>(this.baseUrl + '/trainee-bio-data-general-info/get-autocompletePnoForFamilyInfo?pno='+pno)
    .pipe(
      map((response:[]) => response.map(item => item))
    )
}
  //dropdown data 
  getselectedmaritialstatus(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/marital-status/get-selectedMaritialStatuses')
  }
  getselectedbnabatch(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/bna-batch/get-selectedBnaBatchs')
  }
  getselectedrank(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/ranks/get-selectedRanks')
  }
  getselectedbranch(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/branch/get-selectedBranchs')
  }
  getselecteddivision(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/division/get-selectedDivisions')
  }
  getselecteddistrict(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/district/get-selectedDistricts')
  }
  getdistrictbydivision(id:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/district/get-selectedDistrictByDivisions?divisionId=' + id)
  }
  getselectedthana(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/thana/get-selectedThanas')
  }
  getthanaByDistrict(id:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/thana/getSelectedThanaByDistrict?districtid=' + id);
  }
  getselectedheight(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/height/get-selectedHeight')
  }
  getselectedweight(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/weights/get-selectedWeights')
  }
  getselectedcolorofeye(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/color-of-eye/get-selectedColorOfEyes')
  }
  getselectedgender(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/gender/get-selectedGender')
  }
  getselectedbloodgroup(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/blood-group/get-selectedBloodGroups')
  }
  getselectednationality(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/nationality/get-selectedNationalities')
  }
  getselectedCountry(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/country/get-selectedCountries')
  }
  getselectedreligion(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/religion/get-selectedReligions')
  }
  getselectedcaste(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/Caste/get-selectedCastes')
  }

  getcastebyreligion(id:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/Caste/get-selectedCasteByReligion?religionId='+id)
  }

  getselectedhaircolor(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/hair-color/get-selectedHairColor')
  }
  // getselectedMaritialStatus(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/marital-status/get-selectedMaritialStatuses')
  // }

  find(id: number) {
    return this.http.get<BIODataGeneralInfo>(this.baseUrl + '/trainee-bio-data-general-info/get-traineedetail/' + id);
  }
   
  findTraineeDetails(id: number) {
    return this.http.get<BIODataGeneralInfo>(this.baseUrl + '/trainee-bio-data-general-info/get-traineedetails/' + id);
  }
   
  getCourseDurtationInfoByTrainee(id) {
    return this.http.get<any[]>(this.baseUrl + '/course-duration/get-courseDurtationInfoByTrainee?traineeId=' + id);
  }

  //return this.http.put(this.baseUrl + '/election/update-election/'+id, model);
  updatePassword(model: any) {
    return this.http.post(this.securityUrl + '/Users/update-paswordfor-individualuser', model);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/trainee-bio-data-general-info/update-traineeBioDataGeneralInfo/'+id, model);
  }

  submit(model: any) {
    return this.http.post(this.baseUrl + '/trainee-bio-data-general-info/save-traineeBioDataGeneralInfo', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/trainee-bio-data-general-info/delete-traineeBioDataGeneralInfo/'+id);
  }

  uploadFile(file: File, traineeStatusId: number) {
    const formData = new FormData();
    formData.append('file', file);
    
    // Add the missing '&' between courseDurationId and courseNameId
    const url = `${this.baseUrl}/trainee-bio-data-general-info/post-biodataExeclfile?traineeStatusId=${traineeStatusId}`;
  
    return this.http.post(url, formData)
      .pipe(
        catchError(error => {
          console.error('Upload failed:', error);
          return throwError(() => new Error('File upload failed, see console for details.'));
        })
      );
  }
  uploadServiceInstructorFile(file: File, branchId) {
    const formData = new FormData();
    formData.append('file', file);
    
    // Add the missing '&' between courseDurationId and courseNameId
    const url = `${this.baseUrl}/trainee-bio-data-general-info/get-upload-service-instructor-execl-file?branchId=${branchId}`;
  
    return this.http.post(url, formData)
      .pipe(
        catchError(error => {
          console.error('Upload failed:', error);
          return throwError(() => new Error('File upload failed, see console for details.'));
        })
      );
  }
  uploadServiceInstructorFileByAdmin(file: File) {
    const formData = new FormData();
    formData.append('file', file);
    
    // Add the missing '&' between courseDurationId and courseNameId
    const url = `${this.baseUrl}/trainee-bio-data-general-info/get-upload-service-instructor-execl-file-by-admin`;
  
    return this.http.post(url, formData)
      .pipe(
        catchError(error => {
          console.error('Upload failed:', error);
          return throwError(() => new Error('File upload failed, see console for details.'));
        })
      );
  }

  getSelectedTraineeByparameterRequest(pno){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/trainee-bio-data-general-info/get-autocompletePnoAndName?pNo='+pno)
      .pipe(
        map((response:[]) => response.map(item => item))
      )
  }

  uploadExcelBioDataFileForOfficersAndCivil(file: File, traineeStatusId: number, officerTypeId: number) {
    const formData = new FormData();
    formData.append('file', file);
    
    // Add the missing '&' between courseDurationId and courseNameId
  
    const url = `${this.baseUrl}/trainee-bio-data-general-info/post-biodataExeclfileForOfficerAndCivil?traineeStatusId=${traineeStatusId}&officerTypeId=${officerTypeId}`;
  
    return this.http.post(url, formData)
      .pipe(
        catchError(error => {
          console.error('Upload failed:', error);
          return throwError(() => new Error('File upload failed, see console for details.'));
        })
      );
  }

  findSchoolById(id: any) {
    return this.http.get<any>(this.baseUrl + '/base-School-name/get-baseSchoolNameDetail/' + id);
  }

  getselectedbaseschools(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchools')
  }

}
