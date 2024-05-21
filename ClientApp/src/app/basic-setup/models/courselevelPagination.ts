import {CourseLevel} from './course-level';

export interface ICourseLevelPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: CourseLevel[];
}

export class CourseLevelPagination implements ICourseLevelPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: CourseLevel[] = [];


}
