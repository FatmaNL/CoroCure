import {Component, OnInit} from '@angular/core';
import { PatientService } from './patient.service';
import { TabPatient } from './patient';

@Component ({
    selector :'pm-patient',
    templateUrl : './patient.component.html',
})
export class PatientComponent implements OnInit {
    patients: TabPatient[]=[];
    errorMessage: string;

    constructor(private patientservice: PatientService){

    }

    ngOnInit(){
     this.patientservice.getPatients().subscribe({
         next: patients => this.patients = patients,
         error: err => this.errorMessage = err
        });
    }

    deletePatient(id: number): void {
        this.patientservice.deletePatient(id).subscribe(
            (data:void) => {
                let index: number = this.patients.findIndex(p => p.id == id);
                this.patients.splice(index, 1);
            },
            (err: any) => console.log(err)
        );
    }

}