import { PremiumCalculator } from "../Models/PremiumCalculator";

export abstract class IPremiumCalcFacade{
    abstract calculatePremium(objPremium:PremiumCalculator);
}