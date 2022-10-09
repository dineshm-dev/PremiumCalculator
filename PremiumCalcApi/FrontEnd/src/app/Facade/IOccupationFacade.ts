import { Observable } from "rxjs";
import { Occupation } from "../Models/Occupation";

export abstract class IOccupationFacade{
    abstract getOccupationDetails(): Observable<Occupation[]>;
}