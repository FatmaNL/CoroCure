import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { TabCardiologue } from './cardiologue';
import { CardiologueService } from './cardiologue.service';
import { __assign } from 'tslib';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-cardiologue',
  templateUrl: './cardiologue.component.html',
  styleUrls: ['./cardiologue.component.css']
})
export class CardiologueComponent implements OnInit {
  cardiologues: TabCardiologue[] = [];
  errorMessage: string;
  cardiologue: TabCardiologue = new TabCardiologue();
  selectedCardiologue: TabCardiologue;

  @ViewChild("dismissCreateDialog") dismissCreateDialog: ElementRef;
  @ViewChild("dismissUpdateDialog") dismissUpdateDialog: ElementRef;

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

  getCardiologue(cin: number) {
    this.cardiologueservice.getCardiologue(cin).subscribe({
        next: cardiologue => this.cardiologue = cardiologue,
        error: err => this.errorMessage = err
    });
}

  deleteCardiologue(id: number): void {
    this.cardiologueservice.deleteCardiologue(id).subscribe(
      (data: void) => {
        let index: number = this.cardiologues.findIndex(c => c.cin == id);
        this.cardiologues.splice(index, 1);
      },
      (err: any) => console.log(err)
    );
  }

  addCardiologue(): void {
    this.cardiologue.cin = Number(this.cardiologue.cin);
    this.cardiologueservice.addCardiologue(this.cardiologue)
      .subscribe(
        (data: TabCardiologue) => {
          console.log(data);
          this.cardiologue = new TabCardiologue();
          this.dismissCreateDialog.nativeElement.click();
          this.getCardiologues();
        },
        (err: any) => console.log(err)
      )
  }

  setSelection(cardiologue: TabCardiologue) {
    this.selectedCardiologue = cardiologue;
}

updateCardiologue(cardiologue: TabCardiologue): void {
  this.cardiologueservice.updateCardiologue(cardiologue)
      .subscribe(
          () => {
              this.dismissUpdateDialog.nativeElement.click();
              this.getCardiologues();
          },
          (error) => {
              console.log(error)
          });
}


  cardiologueClicked(): void {
    console.log('cardiologue clicked');
  }

}
