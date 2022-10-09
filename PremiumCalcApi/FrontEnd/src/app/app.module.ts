import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomvalidationService } from './Common/Validators/CustomValidators';
import { PremiumformComponent } from './Presentation/premiumform/premiumform.component';
import { OccupationService } from './Core/OccupationService';
import { HttpClientModule } from '@angular/common/http';
import { HttpService } from './Common/Services/http.service';
import { PremiumCalcService } from './Core/PremiumCalcService';
import { IPremiumCalcFacade } from './Facade/IPremiumCalcFacade';
import { PremiumCalcFacade } from './Facade/PremiumCalcFacade';
import { IOccupationFacade } from './Facade/IOccupationFacade';
import { OccupationFacade } from './Facade/OccupationFacade';

@NgModule({
  declarations: [
    AppComponent,
    PremiumformComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [CustomvalidationService, 
    OccupationService, PremiumCalcService, HttpService,
     {provide:IPremiumCalcFacade, useClass:PremiumCalcFacade},
     {provide:IOccupationFacade, useClass:OccupationFacade}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
