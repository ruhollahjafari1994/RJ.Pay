import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { FilterSortOrderBy } from 'src/app/data/models/common/filterSortOrderBy';
import { Subscription } from 'rxjs';
import { Entry } from 'src/app/data/models/accountant/entry';

import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Pagination } from 'src/app/data/models/common/pagination';
import { EntryService } from 'src/app/core/_services/panel/accountant/entry.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import * as fromStore from 'src/app/store';
import { Store } from '@ngrx/store';


@Component({
  selector: 'app-entry-pardakht',
  templateUrl: './entry-pardakht.component.html',
  styleUrls: ['./entry-pardakht.component.css']
})
export class EntryPardakhtComponent implements OnInit, OnDestroy {
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  subManager = new Subscription();
  entries: MatTableDataSource<Entry>;
  entriesArray: Entry[];
  pagination: Pagination;
  displayedColumns: string[] = ['id', 'ownerName', 'isApprove', 'isPardakht', 'isReject',
    'price', 'textForUser', 'actions'];

  filterSortOrderBy: FilterSortOrderBy = {
    sortDirection: '',
    sortHeader: '',
    searchKey: ''
  };

  loadingHideFlag = false;
  noContentHideFlag = true;
  constructor(private entryService: EntryService,
    private router: Router, private route: ActivatedRoute,
    private alertService: ToastrService, private store: Store<fromStore.State>) { }

  ngOnInit() {
    this.loadgetEntries();
  }
  ngOnDestroy() {
    this.subManager.unsubscribe();
  }
  copied() {
    this.alertService.info('', 'کپی شد');
  }
  loadgetEntries() {
    this.route.data.subscribe(data => {
      this.entries = new MatTableDataSource(data.entriespardakht.result);
      this.pagination = data.entriespardakht.pagination;
      this.entriesArray = data.entriespardakht.result;
      this.entries.sort = this.sort;
      this.loadingHideFlag = true;
      if (data.entriespardakht.result.length === 0) {
        this.noContentHideFlag = false;
      }
    });

  }
  paginatorEvent(filter: any) {

    let { searchKey, sortDirection, sortHeader } = this.filterSortOrderBy;

    if (searchKey === undefined || searchKey == null) {
      searchKey = '';
    }
    if (sortDirection === undefined || sortDirection == null) {
      sortDirection = '';
    }
    if (sortHeader === undefined || sortHeader == null) {
      sortHeader = '';
    }
    this.subManager.add(
      this.entryService.getEntriesPardakht(
        filter.pageIndex, filter.pageSize,
        searchKey.trim(), sortHeader, sortDirection)
        .subscribe((data) => {
          this.entries = new MatTableDataSource(data.result);
          this.pagination = data.pagination;
          this.entriesArray = data.result;
          this.entries.sort = this.sort;
        }, error => {
          this.alertService.error(error);
        })
    )
  }
  sortDataEvent(sort: any) {
    this.filterSortOrderBy.sortHeader = sort.active;
    this.filterSortOrderBy.sortDirection = sort.direction;
    this.applyFilter();
  }
  onSearchClear() {
    this.filterSortOrderBy.searchKey = '';
    this.applyFilter();
  }
  applyFilter() {
    let { searchKey, sortDirection, sortHeader } = this.filterSortOrderBy;
    if (searchKey === undefined || searchKey == null) {
      searchKey = '';
    }
    if (sortDirection === undefined || sortDirection == null) {
      sortDirection = '';
    }
    if (sortHeader === undefined || sortHeader == null) {
      sortHeader = '';
    }
    this.subManager.add(
      this.entryService.getEntriesPardakht(
        this.pagination.currentPage, this.pagination.itemsPerPage,
        searchKey.trim(), sortHeader, sortDirection)
        .subscribe((data) => {
          this.entries = new MatTableDataSource(data.result);
          this.pagination = data.pagination;
          this.entriesArray = data.result;
          this.entries.sort = this.sort;
        }, error => {
          this.alertService.error(error);
        })
    )
  }

  onApproveChange(event: any, entryId: string) {
    this.subManager.add(
      this.entryService.changeApproveEntry(entryId, event.checked)
        .subscribe(() => {
          this.applyFilter();
          if (event.checked === true) {
            this.store.dispatch(new fromStore.DecUnCheckedEntryCount());
            this.alertService.success('واریزی تایید شد', 'موفق');
          } else {
            this.store.dispatch(new fromStore.IncUnCheckedEntryCount());
            this.alertService.success('واریزی از حالت تایید خارج شد', 'موفق');
          }
        }, error => {
          this.alertService.error(error);
        })
    )
  }
  onPardakhtChange(event: any, entryId: string) {
    this.subManager.add(
      this.entryService.changePardakhtEntry(entryId, event.checked)
        .subscribe(() => {
          this.applyFilter();
          if (event.checked === true) {
            this.store.dispatch(new fromStore.DecUnSpecifiedEntryCount());
            this.alertService.success('واریزی پرداخت شد', 'موفق');
          } else {
            this.store.dispatch(new fromStore.IncUnSpecifiedEntryCount());
            this.alertService.success('واریزی از حالت پرداخت خارج شد', 'موفق');
          }
        }, error => {
          this.alertService.error(error);
        })
    )
  }
  onRejectChange(event: any, entryId: string) {
    this.subManager.add(
      this.entryService.changeRejectEntry(entryId, event.checked)
        .subscribe(() => {
          this.applyFilter();
          if (event.checked === true) {
            this.store.dispatch(new fromStore.DecUnSpecifiedEntryCount());
            this.alertService.success('واریزی رد شد', 'موفق');
          } else {
            this.store.dispatch(new fromStore.IncUnSpecifiedEntryCount());
            this.alertService.success('واریزی از حالت رد خارج شد', 'موفق');
          }
        }, error => {
          this.alertService.error(error);
        })
    )
  }

}
