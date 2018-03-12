import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, Response } from '@angular/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DetailService } from '../service/detail.service';

@Component({
    selector: 'appHome',
    template: `<h1>Welcome {{userName}} to Main Page</h1>`,
     providers: [DetailService],
})

export class HomeComponent implements OnInit, OnDestroy {
    private uName: any;
    private route$: any;
    private userName: any;
    constructor(private route: ActivatedRoute , private detailService : DetailService) { }
    ngOnInit() {
        this.route$ = this.route.params.subscribe(
            (params: Params) => {
                console.log(params);
                this.uName = params["id"]; // cast to number
            }
        );
        this.detailService.getDetails(this.uName).subscribe(data => {
            this.userName = data;
            console.log(data);
        })
    }
    ngOnDestroy() {
        if (this.route$) this.route$.unsubscribe();
    }
}
