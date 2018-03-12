import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, Response } from '@angular/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'appContact',
    template: `<h1>Contact</h1>
<p></p>
<h4>The contact details will not be uploaded in the learning template.<h4>
`
})

export class ContactComponent implements OnInit, OnDestroy{

    private uName: any;
    private route$: any;
    constructor(private route: ActivatedRoute) { }
    ngOnInit() {
        this.route$ = this.route.params.subscribe(
            (params: Params) => {
                console.log(params);
                this.uName = params["id"]; // cast to number
            }
        );
    }
    ngOnDestroy() {
        if (this.route$) this.route$.unsubscribe();
    }}
