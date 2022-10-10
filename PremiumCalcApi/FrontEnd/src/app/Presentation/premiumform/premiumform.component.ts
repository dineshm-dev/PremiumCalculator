import { Component, OnInit } from '@angular/core';
import { discardPeriodicTasks } from '@angular/core/testing';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as internal from 'assert';
import { CustomvalidationService } from 'src/app/Common/Validators/CustomValidators';
import { OccupationService } from 'src/app/Core/OccupationService';
import { PremiumCalcService } from 'src/app/Core/PremiumCalcService';
import { IOccupationFacade } from 'src/app/Facade/IOccupationFacade';
import { IPremiumCalcFacade } from 'src/app/Facade/IPremiumCalcFacade';
import { Occupation } from 'src/app/Models/Occupation';
import { PremiumCalculator } from 'src/app/Models/PremiumCalculator';

@Component({
  selector: 'app-premiumform',
  templateUrl: './premiumform.component.html',
  styleUrls: ['./premiumform.component.css']
})
export class PremiumformComponent implements OnInit {
  
  title = 'Calculate Premium';
  premiumCalcForm: FormGroup;
  addEditUserValidationMessages : any;
  occupationList : Occupation[] = [];
  submitted = false;
  occupationId: number;
  calculatedamount : number = 0;
  invalidAgeRange: boolean;
  loader = false;
  inavlidOccupation = false;
  error : string = "";

  constructor(private _fb: FormBuilder, 
    private customValidator: CustomvalidationService,
    private occupationService:IOccupationFacade,
    private premiumCalcService: IPremiumCalcFacade){}

  ngOnInit() {

     this.loader = true;
     this.occupationService.getOccupationDetails().subscribe(
      (data) => {  this.loader = false; return this.occupationList = data;},
      (error) => { this.loader = false;}
     )

    // this.occupationList = [ { value : "1", displayText:"Cleaner" },  { value : "2", displayText:"Doctor" },  
    // { value : "3", displayText:"Author" },     { value : "4", displayText:"Farmer" },
    // { value : "5", displayText:"Mechanic" }];
     this.createForm();
  }

  createForm() {
		this.premiumCalcForm = this._fb.group({
			
			name: ['', Validators.required],
			age: ['', [Validators.required, this.customValidator.numericvalidator.bind(this.customValidator),
      Validators.maxLength(2),]
    ],
    occupations:[null, [Validators.required]],
    occupationId:[],
   // occupation:[0, Validators.required],
    dateofbirth:['',Validators.required],
    deathsumInsured:['',Validators.required]
		});
		
  }
  get premiumFormControl() {
    return this.premiumCalcForm.controls;
  }

  onSubmit() {
    this.error = "";
    this.submitted = true;


    if (this.premiumCalcForm.valid) {
      this.loader = true;
      
      console.log(this.premiumCalcForm.getRawValue());
      let obj : any = this.premiumCalcForm.getRawValue();
      let objpremimCalc:PremiumCalculator = {
          name : obj.name, age : obj.age, occupationId :  Number.parseInt(obj.occupationId), 
          dateOfBirth : obj.dateofbirth.toString(), 
          deathSumInsured : Number.parseFloat(obj.deathsumInsured)
      };

      this.loader = true;
      this.premiumCalcService.calculatePremium(objpremimCalc).subscribe(
        (data)=> {this.loader = false;this.calculatedamount = data},
        (error) => {this.loader = false; this.error = error;}
      )

      return false;
    }

  }

  OnOccupationSelected(value){
    this.premiumCalcForm.controls.occupationId.setValue(value);
    this.inavlidOccupation = false;
    if(value != "-1"){
      console.log(value);
      if(this.premiumCalcForm.valid)
      this.onSubmit();
    }
    else{
      this.inavlidOccupation = true;
      this.calculatedamount = 0;
    }
  }

   CalculateAge(): void
     {
         if(!this.premiumCalcForm.controls.dateofbirth.pristine &&
          this.premiumCalcForm.controls.dateofbirth.valid ){
            var timeDiff = Math.abs(Date.now() - Date.parse(this.premiumCalcForm.controls.dateofbirth.value)
            );
            //Used Math.floor instead of Math.ceil
            //so 26 years and 140 days would be considered as 26, not 27.
            let age = Math.floor((timeDiff / (1000 * 3600 * 24))/365);
            this.premiumCalcForm.controls.age.setValue(age);

            if(age > 18 && age < 60){
            this.invalidAgeRange = false;
            }
            else
            this.invalidAgeRange = true;
    }
  }

}
