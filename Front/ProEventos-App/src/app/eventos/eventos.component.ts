import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  standalone: true,
  imports: [CommonModule,
            HttpClientModule],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss'
})
export class EventosComponent implements OnInit {

  public eventos: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    const apiUrl = 'http://localhost:5283/api/Eventos';

    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.eventos = data;
        console.log('Eventos recuperados com sucesso:', this.eventos);
      },
      (error) => {
        console.error('Erro ao recuperar eventos:', error);
      }
    );
  }
}
