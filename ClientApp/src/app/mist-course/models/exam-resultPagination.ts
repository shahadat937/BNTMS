import {ExamResult} from './exam-result';

export interface IExameRsultPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ExamResult[]; 
}

export class ExameRsultPagination implements IExameRsultPagination { 
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ExamResult[] = []; 
}
 