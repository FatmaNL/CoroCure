import { Component, OnInit } from '@angular/core';
import { AngioplastieDTO } from '../models/angioplastie.dto';
import { CardiologueDTO } from '../models/cardiologue.dto';
import { TabCardiologue } from '../cardiologue/cardiologue';
import { TabPatient } from '../patients/patient';
import { CoronarographieService } from '../coronarographie/coronarographie.service';
import { CardiologueService } from '../cardiologue/cardiologue.service';
import { PatientService } from '../patients/patient.service';
import { ProcedureDTO } from '../models/procedure.dto';
import { MaterielDTO } from '../models/materiel.dto';
import { StentDTO } from '../models/stent.dto';
import { GuideDTO } from '../models/guide.dto';
import { BallonDTO } from '../models/ballon.dto';
import { CoronarographieDTO } from '../models/coronarographie.dto';
import { AngioplastieService } from './angioplastie.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-angioplastie',
  templateUrl: './angioplastie.component.html',
  styleUrls: ['./angioplastie.component.css']
})
export class AngioplastieComponent implements OnInit {

  public cardiologues: TabCardiologue[] = [];
  public coronarographies: CoronarographieDTO[];
  public patients: TabPatient[] = [];
  public angioplastie: AngioplastieDTO;
  public operateurs: CardiologueDTO;
  public procedure: ProcedureDTO;
  public selectedProcedure: ProcedureDTO;

  public materiel: MaterielDTO;
  public materielBallon: BallonDTO;
  public materielStent: StentDTO;
  public materielGuide: GuideDTO;

  public typeMateriel: string;

  constructor(
    private coronarographieService: CoronarographieService,
    private angioplastieService: AngioplastieService,
    private cardiologueservice: CardiologueService,
    private patientService: PatientService,
    private toast: ToastrService
  ) {
    this.angioplastie = new AngioplastieDTO();
    this.procedure = new ProcedureDTO();
    this.materiel = new MaterielDTO();
    this.materielStent = new StentDTO();
    this.materielBallon = new BallonDTO();
    this.materielGuide = new GuideDTO();
    this.selectedProcedure = new ProcedureDTO();
  }

  ngOnInit(): void {
    this.getCardiologues();
    this.getCoronarographie();
    this.getPatients();

    console.log(this.coronarographies);
  }
  getCoronarographie(): void {
    this.coronarographieService.get().subscribe({
      next: data => { this.coronarographies = data; console.log("Data: " + this.coronarographies); },
      error: err => { console.error(err); }
    });
  }

  getCardiologues(): void {
    this.cardiologueservice.getCardiologues().subscribe({
      next: cardiologues => { this.cardiologues = cardiologues; },
      error: err => { console.error(err); }
    });
  }

  getPatients(): void {
    this.patientService.getPatients().subscribe({
      next: patients => {
        this.patients = patients;
      },
      error: err => {
        console.error(err);
      }
    });
  }

  public ajouterAngioplatie(): void {
    this.angioplastieService.add(this.angioplastie).subscribe({
      next: () => this.toast.success('Angioplastie enregistrée avec succès'),
      error: () => this.toast.error('Enregistrement échoué')
    });
  }

  public ajouterMateriel(): void {
    console.log(this.selectedProcedure);

    if (this.typeMateriel === 'ballon') {
      const b = new BallonDTO();
      b.TailleDesilet = this.materiel.TailleDesilet;
      b.CGReseauG = this.materiel.CGReseauG;
      b.CGReseauD = this.materiel.CGReseauD;
      b.Pontage = this.materiel.Pontage;

      b.Type = this.materielBallon.Type;
      b.Diametre = this.materielBallon.Diametre;
      b.Longueur = this.materielBallon.Longueur;
      b.Phase = this.materielBallon.Phase;

      console.log('adding ballon');
      this.selectedProcedure.Ballons.push(b);

      this.materielBallon = new BallonDTO();
    }

    if (this.typeMateriel === 'guide') {
      const b = new GuideDTO();
      b.TailleDesilet = this.materiel.TailleDesilet;
      b.CGReseauG = this.materiel.CGReseauG;
      b.CGReseauD = this.materiel.CGReseauD;
      b.Pontage = this.materiel.Pontage;

      b.Type = this.materielGuide.Type;

      if (!this.selectedProcedure.Guides) {
        this.selectedProcedure.Guides = new Array<GuideDTO>();
      }

      console.log('adding guide');
      this.selectedProcedure.Guides.push(b);

      this.materielGuide = new GuideDTO();
    }

    if (this.typeMateriel === 'stent') {
      const b = new StentDTO();
      b.TailleDesilet = this.materiel.TailleDesilet;
      b.CGReseauG = this.materiel.CGReseauG;
      b.CGReseauD = this.materiel.CGReseauD;
      b.Pontage = this.materiel.Pontage;

      b.Type = this.materielStent.Type;
      b.Diametre = this.materielStent.Diametre;
      b.Longueur = this.materielStent.Longueur;
      b.Marque = this.materielStent.Marque;

      console.log('adding stent');
      this.selectedProcedure.Stents.push(b);

      this.materielStent = new StentDTO();
    }

    this.materiel = new MaterielDTO();
  }

  public ajouterProcedure(): void {
    const procedure = new ProcedureDTO();
    procedure.Technique = this.procedure.Technique;
    procedure.Resultat = this.procedure.Resultat;
    procedure.TIMIFinal = this.procedure.TIMIFinal;

    this.angioplastie.procedures.push(procedure);
  }

}
