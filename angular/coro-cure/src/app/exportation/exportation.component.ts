import { Component, OnInit } from '@angular/core';
import { ExportationDTO } from '../models/exportation.dto';
import { ExportationService } from './exportation.service';

@Component({
  selector: 'app-exportation',
  templateUrl: './exportation.component.html',
  styleUrls: ['./exportation.component.css']
})
export class ExportationComponent implements OnInit {

  public exportations: ExportationDTO[];
  blob: Blob;

  constructor(
    private exportationService: ExportationService
  ) { }

  ngOnInit(): void {

    this.exportationService.get().subscribe({
      next: data => this.exportations = data,
      error: error => console.log(error)
    });
  }

  public export(patientId: number, interventionId: number) {
    this.exportationService.export(patientId, interventionId).subscribe((data) => {

      this.blob = new Blob([data], { type: 'application/pdf' });

      const downloadURL = window.URL.createObjectURL(data);
      const link = document.createElement('a');
      link.href = downloadURL;
      link.download = 'help.pdf';
      link.click();
    });
  }

}
