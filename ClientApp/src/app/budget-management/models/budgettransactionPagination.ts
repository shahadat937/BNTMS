import { BudgetTransaction } from "./budgettransaction";

export interface IBudgetTransactionPagination{
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: BudgetTransaction[];
}

export class BudgetTransactionPagination implements IBudgetTransactionPagination{
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: BudgetTransaction[] = [];
}