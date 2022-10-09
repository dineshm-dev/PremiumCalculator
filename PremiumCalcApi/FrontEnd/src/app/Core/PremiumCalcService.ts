import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpService } from "../Common/Services/http.service";
import { PremiumCalculator } from "../Models/PremiumCalculator";

@Injectable()
export class PremiumCalcService{

    baseUrl:string = "https://localhost:44316/api/";
    premiumCalculatorApi:string = this.baseUrl + "premiumCalc/CalculatePremium"
    /**
     *
     */
    constructor(private httpService: HttpService) {
         
    }

    calculatePremium(objPremium:PremiumCalculator) : Observable<any>{
        return this.httpService.post(this.premiumCalculatorApi,objPremium);
    }
}