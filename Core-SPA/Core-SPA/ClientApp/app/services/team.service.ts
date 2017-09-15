import { Http } from "@angular/http";
import { Injectable } from "@angular/core";
import 'rxjs/add/operator/map';

@Injectable()
export class TeamServices {
    constructor(private http: Http) { }

    getPlayers() {
        return this.http.get('/api/Players').map(res => res.json());
    }

    getTeams() {
        return this.http.get('api/Teams').map(res => res.json());
    }

//    getTeam(id) {
//        return this.http.get('api/Teams/' + id).map(res => res.json());
//    }


}