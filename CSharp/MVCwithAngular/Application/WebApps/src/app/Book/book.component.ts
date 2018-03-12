import { Component, OnInit,OnDestroy } from '@angular/core';
import { Router , ActivatedRoute, Params} from '@angular/router';
import { Http, Response } from '@angular/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Book } from '../service/book';
import { BookService } from '../service/book.service';

@Component({
    selector: 'appBook',
    templateUrl: './book.component.html',
    providers: [BookService],
})

export class BookComponent implements OnInit,OnDestroy {
    private uName: any;
    private route$: any;
    dataBooks: Book[];
    books: Book[];
    addUserForm: boolean = false;
    updateFormBook: boolean = false;
    bookToUpdate: Book;
    addBooksForm: FormGroup;
    book: Book;
    errMsg: string;
    counter: number = 0;
    pages: any[];
    constructor(private route: ActivatedRoute, private bookService: BookService, private formBuilder: FormBuilder) { }
    ngOnInit() {
        this.route$ = this.route.params.subscribe(
            (params: Params) => {
                console.log(params);
                this.uName = params["id"]; // cast to number
            }
        );
        this.bookService.getBooksList().subscribe(data => {
            this.books = data;
            this.dataBooks = this.books;
            //console.log(data);
           this.pages = new Array(Math.ceil(this.books.length / 3));
            this.addBooksForm = this.formBuilder.group({
                bookId: ['0'],
                bookName: ['', Validators.required, Validators.maxLength[50]],
                authors: ['', Validators.required, Validators.maxLength[50]],
                readBook: ['']
            });
        })
    }

    getBookDetail() {
        this.bookService.getBooksList().subscribe(data => {
            this.books = data;
            this.dataBooks = this.books;
            this.pages = new Array(Math.ceil(this.books.length / 3));
        })
    }

    ngOnDestroy() {
        if (this.route$) this.route$.unsubscribe();
    }
    onSubmit() {
        this.addUserForm = false;
        this.book = null;
        this.bookService.addBook(this.addBooksForm.value).subscribe(data => {
            //console.log(data);
            this.book = data;
            if (this.book) {
                //this.bookService.getBooksList().subscribe(data => {
                //    this.books = data;
                //})
                this.getBookDetail();
            }
        })
    }
    onDelete(id: number) {
        this.errMsg = null;
        this.bookService.deleteBook(id).subscribe(data => {
            if (data) {
                //this.bookService.getBooksList().subscribe(data => {
                //    this.books = data;
                //})
                this.getBookDetail();
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
        //console.log(id);
    }
    updateRecord(id: number) {
        this.updateFormBook = false;
        this.errMsg = null;
        this.bookService.updateBook(id, this.addBooksForm.value).subscribe(data => {
            if (data) {
                //this.bookService.getBooksList().subscribe(data => {
                //    this.books = data;
                //})
                this.getBookDetail();
            }
            else {
                this.errMsg = "Some error!";
            }
        })
    }

    onKey(event: any) { 
        if (event.target.value) {
            this.counter = 0;
            this.books = this.dataBooks.filter(x => {
                return x.bookName.toLowerCase().includes((event.target.value.trim()));
            });
            this.pages = new Array(Math.ceil(this.books.length / 3));
            console.log(this.books);
        }
        else
        {
            this.books = this.dataBooks;
            this.pages = new Array(Math.ceil(this.books.length / 3));
        }
    }
}
