import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http, Response } from '@angular/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Skill } from '../service/skill';
import { SkillService } from '../service/skill.service';

@Component({
    selector: 'appSkill',
    templateUrl: './skill.component.html',
    providers: [SkillService],
})

export class SkillComponent implements OnInit, OnDestroy {
    private uName: any;
    private route$: any;
    skills: Skill[];
    addForm: boolean = false;
    updateFormSkill: boolean = false;
    skillToUpdate: Skill;
    addSkillForm: FormGroup;
    skill: Skill;
    errMsg: string=null;
    constructor(private route: ActivatedRoute, private skillService: SkillService, private formBuilder: FormBuilder) { }
    ngOnInit() {
        this.route$ = this.route.params.subscribe(
            (params: Params) => {
                console.log(params);
                this.uName = params["id"]; // cast to number
            }
        );
        this.skillService.getSkillList(this.uName).subscribe(data => {
            this.skills = data;
            console.log(data);
            this.addSkillForm = this.formBuilder.group({
                skills: ['', Validators.required, Validators.maxLength[50]],
                trained: ['']
            });
        })
    }

    onSubmit() {
        this.addForm = false;
        this.skill = null;
        this.errMsg = null;
        this.skillService.addSkill(this.uName,this.addSkillForm.value).subscribe(data => {
            console.log(data);
            if(data ==1)
            {
                this.skillService.getSkillList(this.uName).subscribe(data => {
                    this.skills = data;
                })
            }
            else if (data == -1)
            {
                this.errMsg = "Skill already exist";
            }
            else
            {
                this.errMsg = "Some error occured. Kindly try after sometime."
            }
        })
    }

    onUpdate(skl: string) {
        this.errMsg = null;
        this.skillToUpdate = this.skills.find(s => s.Skills == skl);
        this.addSkillForm.patchValue({
            skills: this.skillToUpdate.Skills,
            trained: this.skillToUpdate.trained

        });
        this.updateFormSkill = true;
        
    }
    updateRecord() {
        console.log(( this.addSkillForm.value));
        var test = this.addSkillForm.value;
        //console.log(test.trained);
        this.addSkillForm.patchValue({
            trained: test.trained == "No" ? false : true,

        });
        this.updateFormSkill = false;
        this.errMsg = null;
        this.skillService.updateSkill(this.uName, this.addSkillForm.value).subscribe(data => {
            if (data) {
                this.skillService.getSkillList(this.uName).subscribe(data => {
                    this.skills = data;
                })
            }
            else {
                this.errMsg = "Some error!";
            }
        })
    }

    onDelete(skl: string) {
        this.errMsg = null;
        this.skillService.deleteSkill(this.uName,skl).subscribe(data => {
            if (data) {
                this.skillService.getSkillList(this.uName).subscribe(data => {
                    this.skills = data;
                })
            }
            else {
                this.errMsg = "Some error!";
            }
        })

    }

    ngOnDestroy() {
        if (this.route$) this.route$.unsubscribe();
    }
}
