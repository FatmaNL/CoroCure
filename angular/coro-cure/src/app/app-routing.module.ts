import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { PatientComponent } from './patients/patient.component';
import { AngioplastieComponent } from './angioplastie/angioplastie.component';
import { CoronarographieComponent } from './coronarographie/coronarographie.component';
import { CardiologueComponent } from './cardiologue/cardiologue.component';
import { ExportationComponent } from './exportation/exportation.component';
import { AuthGuardService } from './auth-guard.service';
import { WelcomeComponent } from './welcome/welcome.component';


const routes: Routes = [
  {
    path: '', component: WelcomeComponent,
    canActivate: [AuthGuardService],
    data: { role: ['Admin', 'Cardiologue', 'Cardiologue Expert', 'Cardiologue Chercheur'] }
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'patients', component: PatientComponent,
    canActivate: [AuthGuardService],
    data: { role: ['Cardiologue', 'Cardiologue Expert', 'Cardiologue Chercheur'] }
  },
  {
    path: 'coronarographie', component: CoronarographieComponent,
    canActivate: [AuthGuardService],
    data: { role: ['Cardiologue', 'Cardiologue Expert', 'Cardiologue Chercheur'] }
  },
  {
    path: 'angioplastie', component: AngioplastieComponent,
    canActivate: [AuthGuardService],
    data: { role: ['Cardiologue', 'Cardiologue Expert', 'Cardiologue Chercheur'] }
  },
  {
    path: 'cardiologue', component: CardiologueComponent,
    canActivate: [AuthGuardService],
    data: { role: ['Admin'] }
  },
  {
    path: 'exportation', component: ExportationComponent,
    canActivate: [AuthGuardService],
    data: { role: ['Cardiologue Expert', 'Cardiologue Chercheur'] }
  },

  { path: '', redirectTo: '', pathMatch: 'full' }
  //{path: '**', component: LoginComponent} //wildcard path
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
