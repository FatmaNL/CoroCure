import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { PatientComponent } from './patients/patient.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { CoronarographieComponent } from './coronarographie/coronarographie.component';
import { AngioplastieComponent } from './angioplastie/angioplastie.component';
import { CardiologueComponent } from './cardiologue/cardiologue.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PatientComponent,
    WelcomeComponent,
    CoronarographieComponent,
    AngioplastieComponent,
    CardiologueComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
