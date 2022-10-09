import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PremiumCalcService } from "../Core/PremiumCalcService";
import { PremiumCalculator } from "../Models/PremiumCalculator";
import { IPremiumCalcFacade } from "./IPremiumCalcFacade";

@Injectable()
export class PremiumCalcFacade implements IPremiumCalcFacade{

    /**
     *
     */
    constructor(private premiumCalcService : PremiumCalcService) {
        
    }

    public premiumCalc$ : Observable<any>;
    
    public calculatePremium(objPremium:PremiumCalculator) : Observable<any>{
        return this.premiumCalcService.calculatePremium(objPremium);
    }
}