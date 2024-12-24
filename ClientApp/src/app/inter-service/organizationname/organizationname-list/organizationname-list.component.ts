import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { OrganizationName } from '../../models/organizationname';
import { OrganizationNameService } from '../../service/organizationname.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';


@Component({
  selector: 'app-organizationname-list',
  templateUrl: './organizationname-list.component.html',
  styleUrls: ['./organizationname-list.component.css']
})
export class OrganizationNameListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: OrganizationName[] = [];
  groupArrays:{ forceType: string; organization: any; }[];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  spans = [];

  displayedColumns: string[] = [ 'sl','forceType','name',  'actions'];
  dataSource: MatTableDataSource<OrganizationName> = new MatTableDataSource();

  selection = new SelectionModel<OrganizationName>(true, []);

  
  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private OrganizationNameService: OrganizationNameService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }
  
  ngOnInit() {
    this.getOrganizationNames();
  }
  
  getOrganizationNames() {
    this.isLoading = true;
    this.OrganizationNameService.getOrganizationNames(this.paging.pageIndex, this.paging.pageSize, this.searchText).subscribe(response => {
  
      this.dataSource.data = response.items;
      this.paging.length = response.totalItemsCount;
  
      const groupedData = this.dataSource.data.reduce((groups, organization) => {
        const forceType = organization.forceType || 'Unknown'; 
        if (!groups[forceType]) {
          groups[forceType] = [];
        }
        groups[forceType].push(organization);
        return groups;
      }, {});
  
      
      this.groupArrays = Object.keys(groupedData).map(forceType => ({
        forceType: forceType,
        organization: groupedData[forceType]
      }));
  
      this.isLoading = false;
      
    });
    
    
  }
  shouldDisplayRowspan(data: any[], currentElement: any, currentIndex: number): boolean {
   
    if (currentIndex === 0) return true;
    return data[currentIndex - 1].forceType !== currentElement.forceType;
  }
  

  getRowspan(data: any[], forceType: string): number {
    return data.filter(item => item.forceType === forceType).length;
  }
  
  
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.filteredData.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected()
      ? this.selection.clear()
      : this.dataSource.filteredData.forEach((row) =>
          this.selection.select(row)
        );
  }
  addNew(){
    
  }
 
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getOrganizationNames();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getOrganizationNames();
  } 


  deleteItem(row) {
    const id = row.organizationNameId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      if (result) {
        this.OrganizationNameService.delete(id).subscribe(() => {
          this.getOrganizationNames();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })
    
  }
}
