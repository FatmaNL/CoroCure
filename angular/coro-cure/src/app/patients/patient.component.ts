import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { PatientService } from './patient.service';
import { TabPatient } from './patient';
import { __assign } from 'tslib';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
    selector: 'pm-patient',
    templateUrl: './patient.component.html',
})
export class PatientComponent implements OnInit {
    patients: TabPatient[] = [];
    errorMessage: string;

    patient: TabPatient = new TabPatient();
    selectedPatient: TabPatient;

    @ViewChild("dismissUpdateDialog") dismissUpdateDialog: ElementRef;
    @ViewChild("dismissCreateDialog") dismissCreateDialog: ElementRef;

    constructor(private patientservice: PatientService, private spinner: NgxSpinnerService) {
    }

    ngOnInit() {
        this.getPatients();
    }

    getPatients(): void {
        this.spinner.show();
        this.patientservice.getPatients().subscribe({
            next: patients => {this.patients = patients; this.spinner.hide();},
            error: err => {this.errorMessage = err; this.spinner.hide();}
        });
    }

    getPatient(id: number) {
        this.patientservice.getPatient(id).subscribe({
            next: patient => this.patient = patient,
            error: err => this.errorMessage = err
        });
    }

    deletePatient(id: number): void {
        this.patientservice.deletePatient(id).subscribe(
            (data: void) => {
                let index: number = this.patients.findIndex(p => p.id == id);
                this.patients.splice(index, 1);
            },
            (err: any) => console.log(err)
        );
    }

    addPatient(): void {
        this.patient.id = Number(this.patient.id);
        this.patientservice.addPatient(this.patient)
            .subscribe(
                (data: TabPatient) => {
                    console.log(data);
                    this.patient = new TabPatient();
                    this.dismissCreateDialog.nativeElement.click();
                    this.getPatients();
                },
                (err: any) => console.log(err)
            )
    }

    setSelection(patient: TabPatient) {
        this.selectedPatient = patient;
    }

    updatePatient(patient: TabPatient): void {
        this.patientservice.updatePatient(patient)
            .subscribe(
                () => {
                    this.dismissUpdateDialog.nativeElement.click();
                    this.getPatients();
                },
                (error) => {
                    console.log(error)
                });
    }

}