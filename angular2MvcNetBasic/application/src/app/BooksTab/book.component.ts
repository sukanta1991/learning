import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Http, Response } from '@angular/http';
import { Book } from './book';
import { BookService } from './book.service';
import { FormBuilder, FormGroup, Validators} from '@angular/forms'


@Component({
    selector: 'appBook',
    templateUrl: './book.component.html',
    providers: [BookService],
    styleUrls: ['./book.component.css']
})

export class BookComponent implements OnInit {
    constructor(private bookService: BookService, private formBuilder: FormBuilder) { }
    books: Book[];
    addUserForm: boolean = false;
    updateFormBook: boolean = false;
    bookToUpdate: Book;
    addBooksForm: FormGroup;
    book: Book;
    errMsg: string;



    ngOnInit(): void {
        this.bookService.getBooksList().subscribe(data => {
        this.books = data;
        console.log(data);
        this.addBooksForm = this.formBuilder.group({
            bookId:['0'],
            bookName: ['', Validators.required, Validators.maxLength[50]],
            authors: ['', Validators.required, Validators.maxLength[50]],
            readBook: ['']
        });
        })
    }
    onSubmit() {
        this.addUserForm = false;
        this.book = null;
        this.bookService.addBook(this.addBooksForm.value).subscribe(data => {
            console.log(data);
            this.book= data;
            if (this.book)
            {
                this.bookService.getBooksList().subscribe(data => {
                    this.books = data;
                })
            }
        })
    }
    onDelete(id: number) {
        this.errMsg = null;
        this.bookService.deleteBook(id).subscribe(data => {
            if (data)
            {
                this.bookService.getBooksList().subscribe(data => {
                    this.books = data;
                })
            }
            else {
                this.errMsg = "Some error!";
            }
        })

    }
    onUpdate(id: number) {
        this.errMsg = null;
        this.bookToUpdate = this.books.find(b => b.bookId == id);
        this.addBooksForm.patchValue({
            bookId: id,
            bookName: this.bookToUpdate.bookName,
            authors: this.bookToUpdate.authors,
            readBook: this.bookToUpdate.readbook

        });
        this.updateFormBook = true;
        console.log(id);
    }
    updateRecord(id: number) {
        this.updateFormBook = false;
        this.errMsg = null;
        this.bookService.updateBook(id, this.addBooksForm.value).subscribe(data => {
            if (data) {
                this.bookService.getBooksList().subscribe(data => {
                    this.books = data;
                })
            }
            else {
                this.errMsg = "Some error!";
            }
        })
    }
}
