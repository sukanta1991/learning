import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, Response } from '@angular/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'appAbout',
    template: `<h1>About</h1>
&nbsp; &nbsp; <h4>This is a test templete for tutorial</h4>`
})

export class AboutComponent implements OnInit, OnDestroy {

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
