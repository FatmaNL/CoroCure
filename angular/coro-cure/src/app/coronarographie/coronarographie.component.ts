import { Component, OnInit } from '@angular/core';
import { TabCardiologue } from 'src/app/cardiologue/cardiologue';
import { CardiologueService } from 'src/app/cardiologue/cardiologue.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { FormGroup, FormBuilder, FormArray} from '@angular/forms';
import { CoronarographieDTO } from '../models/coronarographie.dto';
import { LesionDTO } from '../models/lesion.dto';
import { DescriptionDTO } from '../models/description.dto';
import { CardiologueDTO } from '../models/cardiologue.dto';

@Component({
  selector: 'app-coronarographie',
  templateUrl: './coronarographie.component.html',
  styleUrls: ['./coronarographie.component.css']
})
export class CoronarographieComponent implements OnInit {
  cardiologues: TabCardiologue[] = [];
  cardiologue: TabCardiologue = new TabCardiologue();
  errorMessage: string;
  schemaUrl = 'assets/schema.png';
  lesionForms: FormArray = this.fb.array([]);

  public coronarographie: CoronarographieDTO;
  public lesion: LesionDTO;

  constructor(private cardiologueservice: CardiologueService,
              private spinner: NgxSpinnerService,
              private fb: FormBuilder) { }

  ngOnInit(): void {
    this.getCardiologues();
    this.addLesionForm();

    this.coronarographie = new CoronarographieDTO();
    this.coronarographie.Cardiologue = new CardiologueDTO();
    this.lesion = new LesionDTO();
    this.lesion.Description = new DescriptionDTO();
  }

  getCardiologues(): void {
    this.spinner.show();
    this.cardiologueservice.getCardiologues().subscribe({
      next: cardiologues => { this.cardiologues = cardiologues; this.spinner.hide(); },
      error: err => {this.errorMessage = err; this.spinner.hide(); }
    });
  }

  public addLesion(): void {
    if (this.lesion !== null && this.lesion !== undefined)
    {
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

}
