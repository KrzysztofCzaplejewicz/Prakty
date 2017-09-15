import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-team-form',
    templateUrl: './team.form.component.html',
    styleUrls: ['./team.form.component.css']
})
/** team-form component*/
export class TeamFormComponent implements OnInit
{
    players: any[];

    /** team-form ctor */
    constructor() { }

    /** Called by Angular after team-form component initialized */
    ngOnInit(): void { }
}