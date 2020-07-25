import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { TabCardiologue } from './cardiologue';
import { CardiologueService } from './cardiologue.service';
import { __assign } from 'tslib';

@Component({
  selector: 'app-cardiologue',
  templateUrl: './cardiologue.component.html',
  styleUrls: ['./cardiologue.component.css']
})
export class CardiologueComponent implements OnInit {
  cardiologues: TabCardiologue[]=[];
  errorMessage: string;
  cardiologue: TabCardiologue = new TabCardiologue();
  selectedCadiologue: TabCardiologue;

  @ViewChild("dismissCreateDialog") dismissCreateDialog: ElementRef;

  constructor(private cardiologueservice: CardiologueService) { }

  ngOnInit(): void {
    this.getCardiologues();
  }

  getCardiologues(): void {
    this.cardiologueservice.getCardiologues().subscribe({
      next: cardiologues => this.cardiologues = cardiologues,
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

}
