import { Component, OnInit, Inject, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatDialogRef } from '@angular/material/dialog';
import { Book } from 'src/app/Models/Book';
import { BooksService } from 'src/app/services/books.service';



@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css'],
})

export class BookDetailComponent implements OnInit {
  book: Book;
  
  constructor(private bookService: BooksService,
    private dialogRef: MatDialogRef<BookDetailComponent>,
    private snackBar: MatSnackBar,
    private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private changeDetectorRefs: ChangeDetectorRef,) {
    this.book = {
      id: 0,
      title: '',
      editorial:'',
      pagesNumber: 0,
      author:'',
      isbn:'',
      createdDate: new Date(),
      updateDate: new Date(),
    }
   

  }

  async ngOnInit() {
  
          if (this.data.bookId > 0) {
            this.getById(this.data.bookId);
          }  
  }

  back(): void {
    this.router.navigate(['/books'])
  }
 
 

  save(): void {
  
    this.bookService.create(this.book).subscribe(response => {
      if (response.status == 200) {
        this.openSnackBar(response.message, "OK", "green-snackbar");
        this.dialogRef.close();
      } else {
        this.openSnackBar(response.message, "OK", "red-snackbar");
      }

    },
      (error) => {
        this.openSnackBar(error.error, "OK", "red-snackbar");
      })
  }

  update(): void {
  
    this.bookService.update(this.book.id, this.book).subscribe(response => {
      if (response.status == 200) {
        this.openSnackBar(response.message, "OK", "green-snackbar");
        this.dialogRef.close();
      } else {
        this.openSnackBar(response.message, "OK", "red-snackbar");
      }

    },
      (error) => {
        this.openSnackBar("Ocurrio un error al guardar el registro", "OK", "red-snackbar");
      })
  }

  async getById(id: number) {

    this.bookService.getById(id).subscribe(response => {
      if (response.status == 200) {
        this.book = response.data;

      } else {
        this.openSnackBar(response.message, "OK", "red-snackbar");
      }

    })

  }  

  openSnackBar(message: string, action: string, style: string) {
    this.snackBar.open(message, action, {
      duration: 2500,
      verticalPosition: 'top',
      panelClass: [style, 'login-snackbar'],
    });
  }
}
