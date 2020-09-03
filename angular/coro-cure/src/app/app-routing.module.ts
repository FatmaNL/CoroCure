import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { PatientComponent } from './patients/patient.component';
import { AngioplastieComponent } from './angioplastie/angioplastie.component';
import { CoronarographieComponent } from './coronarographie/coronarographie.component';
import { CardiologueComponent } from './cardiologue/cardiologue.component';
import { ExportationComponent } from './exportation/exportation.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'patients', component: PatientComponent },
  { path: 'coronarographie', component: CoronarographieComponent },
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
