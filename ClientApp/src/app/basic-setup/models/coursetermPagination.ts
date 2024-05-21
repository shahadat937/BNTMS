import {CourseTerm} from './course-term';

export interface ICourseTermination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: CourseTerm[];
}

export class CourseTermPagination implements ICourseTermination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: CourseTerm[] = [];


}
