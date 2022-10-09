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
  providers: [CustomvalidationService, OccupationService, PremiumCalcService, HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
