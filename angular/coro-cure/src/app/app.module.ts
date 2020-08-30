import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { PatientComponent } from './patients/patient.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { CoronarographieComponent } from './coronarographie/coronarographie.component';
import { AngioplastieComponent } from './angioplastie/angioplastie.component';
import { CardiologueComponent } from './cardiologue/cardiologue.component';
import { NgxSpinnerModule } from 'ngx-spinner';

import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ExportationComponent } from './exportation/exportation.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PatientComponent,
    WelcomeComponent,
    CoronarographieComponent,
    AngioplastieComponent,
    CardiologueComponent,
    ExportationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
    CommonModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
