import { ReadingMaterialTitle } from "./ReadingMaterialTitle";


export interface IReadingMaterialTitlePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number; 
    totalItemsCount:number;
    items: ReadingMaterialTitle[]; 
}

export class ReadingMaterialTitlePagination implements IReadingMaterialTitlePagination { 
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ReadingMaterialTitle[] = []; 
}
 