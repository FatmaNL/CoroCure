import { Component, OnInit } from '@angular/core';
import { ExportationDTO } from '../models/exportation.dto';
import { ExportationService } from './exportation.service';
import { AuthenticationService } from '../auth.service';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-exportation',
  templateUrl: './exportation.component.html',
  styleUrls: ['./exportation.component.css']
})
export class ExportationComponent implements OnInit {

  public exportations: ExportationDTO[];
  public role: Observable<string>;
  blobPdf: Blob;

  constructor(
    private exportationService: ExportationService,
    private authService: AuthenticationService
  ) { }

  ngOnInit(): void {

    this.exportationService.get().subscribe({
      next: data => this.exportations = data,
      error: error => console.log(error)
    });

    this.authService.compte.subscribe({
      next: (data) => {
        if (data !== null) {
          this.role = of(data.roles);
        }
        else {
          this.role = of('');
        }
      }
    });
  }

  public exportPdf(patientId: number, interventionId: number) {
    this.exportationService.exportPdf(patientId, interventionId).subscribe((data) => {

      this.blobPdf = new Blob([data], { type: 'application/pdf' });

      const downloadURL = window.URL.createObjectURL(data);
      const link = document.createElement('a');
      link.href = downloadURL;
      link.download = 'rappo-coro.pdf';
      link.click();
    });
  }

  public exportXls(): void {
    this.exportationService.exportXls().subscribe((data) => {

      let blobXls = new Blob([data], { type: 'application/xls' });

      const fileName = `export-data-${new Date().toDateString()}.xls`;
      const downloadURL = window.URL.createObjectURL(data);
      const link = document.createElement('a');
      link.href = downloadURL;
      link.download = fileName;
      link.click();
    });
  }

}
