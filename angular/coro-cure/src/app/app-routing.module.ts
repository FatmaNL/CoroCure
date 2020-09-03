import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { PatientComponent } from './patients/patient.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { AngioplastieComponent } from './angioplastie/angioplastie.component';
import { CoronarographieComponent } from './coronarographie/coronarographie.component';
import { CardiologueComponent } from './cardiologue/cardiologue.component';
import { ExportationComponent } from './exportation/exportation.component';
import { AuthGuardService } from './auth-guard.service';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'welcome', component: WelcomeComponent/* , canActivate: [AuthGuardService] */ },
  { path: 'patients', component: PatientComponent/* , canActivate: [AuthGuardService] */ },
  { path: 'coronarographie', component: CoronarographieComponent /* , canActivate: [AuthGuardService] */},
  { path: 'angioplastie', component: AngioplastieComponent },
  { path: 'cardiologue', component: CardiologueComponent },
  { path: 'exportation', component: ExportationComponent },

  { path: '', redirectTo: 'patients', pathMatch: 'full' }
  //{path: '**', component: LoginComponent} //wildcard path
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
