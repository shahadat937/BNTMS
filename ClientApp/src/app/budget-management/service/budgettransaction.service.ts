import { PostResponse } from './../../core/models/PostResponse';
// import { environment } from './../../../environments/environment';
import { environment } from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BudgetTransaction } from '../models/budgettransaction';
import { SelectedModel } from '../../core/models/selectedModel';
import { map } from 'rxjs';
import { BudgetTransactionPagination, IBudgetTransactionPagination } from '../models/budgettransactionPagination';

@Injectable({
    providedIn: 'root'
  })

export class BudgetTransactionService{
    baseUrl = environment.apiUrl;
    BudgetTransaction:BudgetTransaction[] = [];
    BudetTransactionPagination = new BudgetTransactionPagination();
    BudgetTransactionPagination: any;
    constructor(private http: HttpClient) { }

    getselectedBudgetCode(){
        return this.http.get<SelectedModel[]>(this.baseUrl + '/budget-code/get-selectedBudgetCodes')
      }
    
      getselectedBudgetType(){
        return this.http.get<SelectedModel[]>(this.baseUrl + '/budget-type/get-selectedBudgetTypes')
      }

      getTotalBudgetByBudgetCodeIdRequest(budgetCodeId){
        return this.http.get<SelectedModel[]>(this.baseUrl + '/budget-code/get-totalBudgetByBudgetCodeIdRequest?budgetCodeId='+budgetCodeId+'');
      }

      getSelectedBudgetCodeNameByBudgetCodeId(budgetCodeId){
        return this.http.get<SelectedModel[]>(this.baseUrl + '/budget-code/get-selectedBudgetCodeByBudgetCodeIdRequest?budgetCodeId='+budgetCodeId+'')
      }

      getDeskAuthorityName(deskAuthority){
        return this.http.get<SelectedModel[]>(this.baseUrl + '/desk-authority/get-deskAuthorityRequest'+deskAuthority+'');
      }


      getBudgetTransaction(pageNumber, pageSize,searchText,budgetCodeId,budgetTypeId)
      {
        console.log('budget code',budgetCodeId)
        let params = new HttpParams();

        params = params.append('searchText', searchText.toString());
        params = params.append('pageNumber', pageNumber.toString());
        params = params.append('pageSize', pageSize.toString());
        
        params = params.append('budgetCodeId', budgetCodeId.toString()); 
        params = params.append('budgetTypeId', budgetTypeId.toString()); 

        return this.http.get<IBudgetTransactionPagination>(this.baseUrl + '/budget-transaction/get-BudgetTransaction', { observe: 'response', params })
    .pipe(
        map(response => {
            console.log('Full API Response:', response);
            console.log('Response Body:', response.body);
            this.BudgetTransaction = [...this.BudgetTransaction, ...response.body?.items || []];
            this.BudgetTransactionPagination = response.body;
            return this.BudgetTransactionPagination;
        })
    );
      }

      find(id: number){
        return this.http.get<BudgetTransaction>(this.baseUrl + '/budget-transaction/get-BudgetTransactionDetail' + id);
      }

      update(id: number, model: any){
        return this.http.put<BudgetTransaction>(this.baseUrl + '/budget-transaction/update-BudgetTransaction' + id,model);
      }

      submit(model:any){
        console.log('Submitting Budget Transaction:', model);
        return this.http.post<PostResponse>(this.baseUrl + '/budget-transaction/save-BudgetTransaction', model).pipe(
           map((BudgetTransaction:PostResponse)=> {
            
            if(BudgetTransaction){
                return BudgetTransaction;
            }
           })
        )
        
      }

      delete(id:number){
        return this.http.delete<BudgetTransaction>(this.baseUrl + '/transaction-type'+ id)
      }
 
}

