import { OnlineLibraryMaterial } from "./onlinelibrarymaterial";


export interface IOnlineLibraryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: OnlineLibraryMaterial []; 
}

export class OnlineLibraryPagination implements IOnlineLibraryPagination { 
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: OnlineLibraryMaterial[] = []; 
}
 