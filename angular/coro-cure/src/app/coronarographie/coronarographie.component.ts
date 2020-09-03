import { Component, OnInit } from '@angular/core';
import { TabCardiologue } from 'src/app/cardiologue/cardiologue';
import { CardiologueService } from 'src/app/cardiologue/cardiologue.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { CoronarographieDTO } from '../models/coronarographie.dto';
import { LesionDTO } from '../models/lesion.dto';
import { DescriptionDTO } from '../models/description.dto';
import { CardiologueDTO } from '../models/cardiologue.dto';
import { CoronarographieService } from './coronarographie.service';
import { TabPatient } from '../patients/patient';
import { PatientService } from '../patients/patient.service';

@Component({
  selector: 'app-coronarographie',
  templateUrl: './coronarographie.component.html',
  styleUrls: ['./coronarographie.component.css']
})
export class CoronarographieComponent implements OnInit {
  cardiologues: TabCardiologue[] = [];
  patients: TabPatient[] = [];
  cardiologue: TabCardiologue = new TabCardiologue();
  errorMessage: string;
  schemaUrl = 'assets/schema.png';
  lesionForms: FormArray = this.fb.array([]);

  public coronarographie: CoronarographieDTO;
  public lesion: LesionDTO;

  private _imc: number;

  constructor(
    private coronarographieService: CoronarographieService,
    private cardiologueservice: CardiologueService,
    private patientService: PatientService,
    private spinner: NgxSpinnerService,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.getCardiologues();
    this.getPatients();
    this.addLesionForm();

    this.coronarographie = new CoronarographieDTO();
    this.lesion = new LesionDTO();
  }

  getCardiologues(): void {
    this.spinner.show();
    this.cardiologueservice.getCardiologues().subscribe({
      next: cardiologues => { this.cardiologues = cardiologues; this.spinner.hide(); },
      error: err => { this.errorMessage = err; this.spinner.hide(); }
    });
  }

  getPatients(): void {
    this.spinner.show();
    this.patientService.getPatients().subscribe({
      next: patients => {
        this.patients = patients;
        this.spinner.hide();
      },
      error: err => {
        this.errorMessage = err;
        this.spinner.hide();
      }
    });
  }

  public addLesion(): void {
    if (this.lesion !== null && this.lesion !== undefined) {
      this.coronarographie.Lesions.push(this.lesion);
    }
  }

  addLesionForm() {
    this.lesionForms.push(this.fb.group({
      lesionID: [0],
      type: [''],
      degre: [''],
      fluxTIMI: [''],
      descriptionId: [0],
      descriptionSegment: ['']
    }));
  }

  public addCoronarographie(): void {
    this.coronarographie.Cardiologue.CIN = Number(this.coronarographie.Cardiologue.CIN);
    this.coronarographie.Numero = Number(this.coronarographie.Numero);

    this.spinner.show();
    this.coronarographieService.add(this.coronarographie).subscribe(
      data => { this.spinner.hide(); },
      error => { this.spinner.hide(); },
    );
  }

  get imc() {
    const poids = this.coronarographie.FacteursRisqueAntecedants.Poids;
    const taille = this.coronarographie.FacteursRisqueAntecedants.Taille;

    if (poids > 0 && taille > 0) {
      const divider = Math.pow(this.coronarographie.FacteursRisqueAntecedants.Taille, 2);
      if (divider !== undefined && divider !== 0) {
        this._imc = poids / divider;
        this._imc = Number.parseFloat(this._imc.toFixed(2));
        this.coronarographie.FacteursRisqueAntecedants.IMC = this._imc;

        return this.coronarographie.FacteursRisqueAntecedants.IMC;
      }
    }

    return 0;
  }

  get obesite() {
    const poids = this.coronarographie.FacteursRisqueAntecedants.Poids;
    const taille = this.coronarographie.FacteursRisqueAntecedants.Taille;

    if (poids > 0 && taille > 0) {
      const divider = Math.pow(this.coronarographie.FacteursRisqueAntecedants.Taille, 3);
      if (divider !== undefined && divider !== 0) {
        this._imc = poids / divider * 1.2;
        this._imc = Number.parseFloat(this._imc.toFixed(2));
        this.coronarographie.FacteursRisqueAntecedants.IMC = this._imc;

        return this.coronarographie.FacteursRisqueAntecedants.IMC;
      }
    }

    return 0;
  }

  get clCreatinine() {
    let clCreatinine = 0;

    const patient = this.patients.find(p => p.id == this.coronarographie.PatientId);
    const poids = this.coronarographie.FacteursRisqueAntecedants.Poids;

    if (patient === null || patient === undefined)
    {
      return clCreatinine;
    }

    const age = new Date().getFullYear() - new Date(patient.dateNaissance).getFullYear();
    const creatinine = this.coronarographie.Biologie.Creatinine;


    if (isNaN(poids) || poids <= 0 || isNaN(age) || age <= 0 || isNaN(creatinine) || creatinine <= 0)
    {
      return clCreatinine;
    }

    if (patient.sexe.toUpperCase() === 'HOMME') {
      /* Cl(H) = 1,23 x P x (140 - Age)/Créatm */
      clCreatinine = (1.23 * poids * (140 - age)) / creatinine;
    }
    else {
      /* Cl(F) = 1,04 x P x (140 - Age)/Créatm */
      clCreatinine = (1.04 * poids * (140 - age)) / creatinine;
    }

    this.coronarographie.Biologie.CLCreatinine = clCreatinine;
    return clCreatinine;
  }

}
