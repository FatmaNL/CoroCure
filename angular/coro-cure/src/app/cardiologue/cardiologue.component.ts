import { Component, OnInit } from '@angular/core';
import { TabCardiologue } from './cardiologue';
import { CardiologueService } from './cardiologue.service';

@Component({
  selector: 'app-cardiologue',
  templateUrl: './cardiologue.component.html',
  styleUrls: ['./cardiologue.component.css']
})
export class CardiologueComponent implements OnInit {
  cardiologues: TabCardiologue[]=[];
  errorMessage: string;

  constructor(private cardiologueservice: CardiologueService) { }

  ngOnInit(): void {
    this.cardiologueservice.getCardiologues().subscribe({
      next: cardiologues => this.cardiologues = cardiologues,
      error: err => this.errorMessage = err
    })
  }

  deleteCardiologue(id: number): void {
    this.cardiologueservice.deleteCardiologue(id).subscribe(
        (data:void) => {
            let index: number = this.cardiologues.findIndex(c => c.cin == id);
            this.cardiologues.splice(index, 1);
        },
        (err: any) => console.log(err)
    );
}

}
