import { PostResponse } from './../../core/models/PostResponse';

import { environment } from './../../../environments/environment';

import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';

// import { IBudgetAllocationPagination,BudgetAllocationPagination } from '../models/BudgetAllocationPagination';
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

      getTargetAmountByBudgetCodeIdRequest(budgetCodeId){
        return this.http.get<SelectedModel[]>(this.baseUrl + '/budget-code/get-targetAmountByBudgetCodeIdRequest?budgetCodeId='+budgetCodeId+'');
      }

      getBudgetTransaction(pageSize,pageNumber,searchText, budgetCodeId, budgetTypeId)
      {
        let params = new HttpParams();

        params = params.append('searchText', searchText.toString());
        params = params.append('pageNumber', pageNumber.toString());
        params = params.append('pageSize', pageSize.toString()); 
        params = params.append('budgetCodeId', budgetCodeId.toString()); 
        params = params.append('fiscalYearId', budgetTypeId.toString()); 

        return this.http.get<IBudgetTransactionPagination>(this.baseUrl + '/transaction-type/get-BudgetTransaction', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BudgetTransaction = [...this.BudgetTransaction, ...response.body.items];
        this.BudgetTransactionPagination = response.body;
        console.log(response)
        return this.BudgetTransactionPagination;
      })
    );
      }

      find(id: number){
        return this.http.get<BudgetTransaction>(this.baseUrl + '/transaction-type/get-BudgetTransactionDetails' + id);
      }

      update(id: number, model: any){
        return this.http.put<BudgetTransaction>(this.baseUrl + '/transaction-type/update-BudgetTransaction' + id,model);
      }

      submit(model:any){
        return this.http.post<PostResponse>(this.baseUrl + '/transaction-type/save-BudgetTransaction', model).pipe(
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

