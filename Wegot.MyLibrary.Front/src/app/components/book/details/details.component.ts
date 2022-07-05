import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from 'src/app/Models/Book';
import { BooksService } from 'src/app/services/books.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  currentBook: Book;
  message = '';

  constructor(
    private booksService: BooksService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    const id = this.route.snapshot.paramMap.get('id');
    this.getBook(id !== null ? JSON.parse(id) : 0);
  }

  getBook(id: string): void {
    this.booksService.getItem(parseInt(id))
      .subscribe(
        (book: Book) => {
          this.currentBook = book;
          console.log(book);
        },
        (error: any) => {
          console.log(error);
        });
  }
 
  updateBook(): void {
    this.booksService.update(this.currentBook.id, this.currentBook)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The product was updated!';
        },
        error => {
          console.log(error);
        });
  }

  deleteBook(): void {
    this.booksService.delete(this.currentBook.id)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/books']);
        },
        error => {
          console.log(error);
        });
  }

}