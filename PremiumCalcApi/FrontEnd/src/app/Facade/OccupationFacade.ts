import { InjectableCompiler } from "@angular/compiler/src/injectable_compiler";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { OccupationService } from "../Core/OccupationService";
import { Occupation } from "../Models/Occupation";
import { IOccupationFacade } from "./IOccupationFacade";

@Injectable()
export class OccupationFacade implements IOccupationFacade{

    /**
     *
     */
    constructor(private occupationService:OccupationService) {
        
    }

    getOccupationDetails() : Observable<Occupation[]>{
        return this.occupationService.getOccupationDetails();
    }
    

}