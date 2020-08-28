import { Component, OnInit } from '@angular/core';
import { TabCardiologue } from 'src/app/cardiologue/cardiologue';
import { CardiologueService } from 'src/app/cardiologue/cardiologue.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { FormGroup} from '@angular/forms';

@Component({
  selector: 'app-coronarographie',
  templateUrl: './coronarographie.component.html',
  styleUrls: ['./coronarographie.component.css']
})
export class CoronarographieComponent implements OnInit {
  cardiologues: TabCardiologue[] = [];
  cardiologue: TabCardiologue = new TabCardiologue();
  errorMessage: string;
  schemaUrl: string = 'assets/schema.png';
  

  constructor(private cardiologueservice: CardiologueService, private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.getCardiologues();
  }


  getCardiologues(): void {
    this.spinner.show();
    this.cardiologueservice.getCardiologues().subscribe({
      next: cardiologues => { this.cardiologues = cardiologues; this.spinner.hide(); },
      error: err => {this.errorMessage = err; this.spinner.hide(); }
    });
  }

}
