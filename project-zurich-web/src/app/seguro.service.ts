import { Injectable } from '@angular/core';
import axios from 'axios';

@Injectable({
  providedIn: 'root'
})
export class SeguroService {

  private apiUrl = 'https://localhost:3000/api/Seguro';

  async getMediasSeguros(): Promise<number> {
    try {
      const response = await axios.get(`${this.apiUrl}/report-average`);
      console.log(response.data)
      return response.data.mediaPremioComercial;
    } catch (error) {
      console.error('Erro ao obter médias de seguros:', error);
      throw error;
    }
  }
}
