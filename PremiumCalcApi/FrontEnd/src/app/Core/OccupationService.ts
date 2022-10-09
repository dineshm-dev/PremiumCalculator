import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpService } from "../Common/Services/http.service";
import { Occupation } from "../Models/Occupation";

@Injectable()
export class OccupationService{
    baseUrl:string = "https://localhost:44316/api/";
    occupationDetailApi:string = this.baseUrl + "Occupation/GetOccupationDetails"
    constructor(private httpService: HttpService) {
        
    }

    getOccupationDetails() : Observable<Occupation[]>{
        return this.httpService.getByType<Occupation[]>(this.occupationDetailApi);
    }

}