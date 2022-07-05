import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/Models/Book';
import { BooksService } from 'src/app/services/books.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  book : Book = {
    id: 0,
    title: '',
    editorial: '',
    pageNumber: 0,
    author:'',
    isbn:'',
    createdDate: new Date(),
    updateDate: new Date(),
  };
  isBookAdded = false;

  constructor(private booksService: BooksService) { }

  ngOnInit(): void { }

  // Add New
  addBook(): void {
 
    if (!this.book.title) {
      alert('Please add title!');
      return;
    }

    this.booksService.create(this.book)
      .subscribe(
        response => {
          console.log(response);
          this.isBookAdded = true;
        },
        error => {
          console.log(error);
        });
  }

  // Reset on adding new
  newBook(): void {
    this.isBookAdded = false;
    this.book ={
      id: 0,
      title: '',
      editorial: '',
      pageNumber: 0,
      author:'',
      isbn:'',
      createdDate: new Date(),
      updateDate: new Date(),
    };
  }

}