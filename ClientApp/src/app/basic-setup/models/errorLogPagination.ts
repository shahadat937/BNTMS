import { ErrorLog } from "./ErrorLog";

export interface IErrorLogPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ErrorLog[];
}
export class ErrorLogPagination implements IErrorLogPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ErrorLog[] = [];


}
