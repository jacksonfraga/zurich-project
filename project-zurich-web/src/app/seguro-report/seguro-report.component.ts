import { Component, OnInit } from '@angular/core';
import { SeguroService } from '../seguro.service';

@Component({
  selector: 'app-seguro-report',
  templateUrl: './seguro-report.component.html',
  styleUrls: ['./seguro-report.component.css'],
})
export class SeguroReportComponent implements OnInit {
  mediaSeguros: number;

  constructor(private seguroService: SeguroService) {
    this.mediaSeguros = 0;
  }

  async ngOnInit(): Promise<void> {
    try {
      this.mediaSeguros = await this.seguroService.getMediasSeguros();
    } catch (error) {
      console.error('Erro ao obter médias de seguros:', error);
    }
  }
}
