import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
 
import { MatTableDataSource } from '@angular/material/table'
import { MatPaginator } from '@angular/material/paginator'
import { MatSort } from '@angular/material/sort'
import { MatSnackBar } from '@angular/material/snack-bar';

import { MatDialog } from '@angular/material/dialog';
import { Book } from '../../Models/Book';
import { BooksService } from '../../services/books.service';
import { BookDetailComponent } from './book-detail/book-detail.component';


@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

 
  displayedColumns = ['isbn', 'title','author','editorial','pagesNumber', 'action']
  pageSize: number = 5;
  filter: string = '';
  dataList: Book[];
 
  dataSource = new MatTableDataSource<Book>();
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private snackBar: MatSnackBar, private bookService:BooksService,
    private dialog: MatDialog) {
 
    this.dataSource.filterPredicate = function (data, filter: string): boolean {
      return data.title?.toString().toLowerCase().includes(filter.toLowerCase())||
      data.author?.toLowerCase().includes(filter.toLowerCase()) ||
      data.editorial?.toLowerCase().includes(filter.toLowerCase())
    };
  }

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.bookService.getAll().subscribe((response) => {

      if (response.status == 200) {
        this.dataList = response.data;
        this.dataSource.data = this.dataList;
      } else {
        this.openSnackBar(response.message, "OK", "red-snackbar");
      }

    });
  }
  public doFilter = (value: any) => {
    this.dataSource.filterPredicate = function (data, filter: string): boolean {
      return data.title?.toString().toLowerCase().includes(filter.toLowerCase())||
      data.author?.toLowerCase().includes(filter.toLowerCase()) ||
      data.editorial?.toLowerCase().includes(filter.toLowerCase())
    };
    this.dataSource.filter = value.trim();
  }
  
 
  deleteItem(id: number) {
    
    this.bookService.delete(id).subscribe(response => {
      if (response.status == 200) {
        this.openSnackBar(response.message, "OK", "green-snackbar");
        this.refresh();
      } else {
        this.openSnackBar(response.message, "OK", "red-snackbar");
      }

    }) 
  }

  openDialog() {
    const dialogRef = this.dialog.open(BookDetailComponent, {
      data: {  bookId: 0 }
    });
    dialogRef.afterClosed().subscribe(result => {
      this.refresh();
    });
  }
 
  openDialogEdit(id: number) {
    const dialogRef = this.dialog.open(BookDetailComponent, {
      data: {  bookId: id }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.refresh();
    });
  }
 
  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
 
  openSnackBar(message: string, action: string, style: string) {
    this.snackBar.open(message, action, {
      duration: 2500,
      verticalPosition: 'top',
      panelClass: [style, 'login-snackbar'],
    });
  }

  refresh() {
    this.getData();
  }

}
